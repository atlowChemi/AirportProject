using Common.DTO;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    /// <summary>
    /// Service to handle the whole orchestra of the airport.
    /// </summary>
    public class AirportService : IAirportService
    {
        /// <summary>
        /// The repository to handle the airplanes.
        /// </summary>
        private readonly IRepository<Airplane> airplaneRepository;
        /// <summary>
        /// The repository to handle the stations.
        /// </summary>
        private readonly IRepository<Station> stationRepository;
        /// <summary>
        /// The repository to handle the station relation.
        /// </summary>
        private readonly IRepository<StationRelation> stationRelationRepository;
        /// <summary>
        /// The repository to handle the control towers.
        /// </summary>
        private readonly IRepository<ControlTower> controlTowerRepository;
        /// <summary>
        /// The repository to handle the flights.
        /// </summary>
        private readonly IRepository<Flight> flightRepository;
        /// <summary>
        /// The repository to handle the flight histories.
        /// </summary>
        private readonly IRepository<FlightHistory> flightHistoryRepository;

        /// <summary>
        /// The Station tree builder.
        /// </summary>
        private readonly IStationTreeBuilderService stationTreeBuilder;
        /// <summary>
        /// The future flight notifier.
        /// </summary>
        private readonly IFutureFlightNotifier notifier;
        /// <summary>
        /// The logger factory for this service.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IAirportService> logger;

        /// <summary>
        /// Generate a new instance of the Airport service.
        /// </summary>
        /// <param name="airplaneRepository">The reposirty to handle the airplanes.</param>
        /// <param name="stationRepository">The reposirty to handle the stations.</param>
        /// <param name="stationRelationRepository">The reposirty to handle the station relations.</param>
        /// <param name="controlTowerRepository">The reposirty to handle the control towers.</param>
        /// <param name="flightRepository">The reposirty to handle the flights.</param>
        /// <param name="flightHistoryRepository">The reposirty to handle the flight histories.</param>
        /// <param name="stationTreeBuilder">The station tree builder</param>
        /// <param name="notifier">The notifier to update regarding future flights.</param>
        /// <param name="loggerFactory">The logger for this service.</param>
        public AirportService(IRepository<Airplane> airplaneRepository,
                              IRepository<Station> stationRepository,
                              IRepository<StationRelation> stationRelationRepository,
                              IRepository<ControlTower> controlTowerRepository,
                              IRepository<Flight> flightRepository,
                              IRepository<FlightHistory> flightHistoryRepository,
                              IStationTreeBuilderService stationTreeBuilder,
                              INotifier notifier,
                              ILoggerFactory loggerFactory)
        {
            this.airplaneRepository = airplaneRepository ?? throw new ArgumentNullException(nameof(airplaneRepository));
            this.stationRepository = stationRepository ?? throw new ArgumentNullException(nameof(stationRepository));
            this.stationRelationRepository = stationRelationRepository ?? throw new ArgumentNullException(nameof(stationRelationRepository));
            this.controlTowerRepository = controlTowerRepository ?? throw new ArgumentNullException(nameof(controlTowerRepository));
            this.flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
            this.flightHistoryRepository = flightHistoryRepository;
            this.stationTreeBuilder = stationTreeBuilder ?? throw new ArgumentNullException(nameof(stationTreeBuilder));
            this.notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            logger = loggerFactory.CreateLogger<IAirportService>();
            CreateStationTrees();
            if (!stationTreeBuilder.WasInitialized)
            {
                InitializeFlightsFromStations();
                InitializeWaitingFlights();
            }
        }

        public IEnumerable<AirplaneDTO> GetAirplanes()
        {
            IEnumerable<Airplane> airplanes;
            try
            {
                airplanes = airplaneRepository.GetAll();
                logger.LogInformation("Successfully retrieved airplanes");
            }
            catch (Exception e)
            {
                logger.LogError(e, "Issue with getting airplanes from DB.");
                airplanes = Enumerable.Empty<Airplane>();
            }
            return airplanes.Select(a => AirplaneDTO.FromDBModel(a));
        }

        public AirportDataDTO GetAirportData(string name)
        {
            ControlTower controlTower = stationTreeBuilder[name]?.ControlTower ??
                throw new KeyNotFoundException("No control tower with given name found!");
            IEnumerable<FlightDTO> flights = GetFlightDtos(controlTower.Id);
            IEnumerable<StationDTO> stations = controlTower.Stations.Select(s => StationDTO.FromDBModel(s));
            IEnumerable<StationRelationDTO> stationRelations = GetStationRelationDtos(controlTower.Stations);
            IEnumerable<StationControlTowerRelationDTO> firstStations = controlTower.FirstStations
                .Select(sctr => StationControlTowerRelationDTO.FromDBModel(sctr));
            ControlTowerDTO controlTowerDTO = ControlTowerDTO.FromDBModel(controlTower);
            logger.LogInformation("Successfully built airport data.");
            return new AirportDataDTO
            {
                ControlTower = controlTowerDTO,
                FirstStations = firstStations,
                Flights = flights,
                StationRelations = stationRelations,
                Stations = stations
            };
        }

        public async Task HandleNewFlightArrivedAsync(Flight flight)
        {
            try
            {
                string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
                IControlTowerService controlTowerService = stationTreeBuilder[controlTowerName] ??
                    throw new KeyNotFoundException("Control tower does not exist");
                flight.ControlTowerId = controlTowerService.ControlTower.Id;
                Flight dbFlight = await flightRepository.AddAsync(flight);
                SendFlightToControlTowerAtTime(flight);
            }
            catch (DbUpdateException e)
            {
                logger.LogCritical(e, "A flight has been lost due to DB updating errors!", flight);
                throw;
            }
            catch (Exception e)
            {
                logger.LogCritical(e, "A flight has been lost due to unknown error!", flight);
                throw;
            }

        }

        public PaginatedDTO<FlightHistoryDTO> GetStationHistory(Guid stationId, int startFrom = 0, int paginationLimit = 15)
        {
            Station station;
            try
            {
                station = stationRepository.GetAll().FirstOrDefault(s => s.Id == stationId);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Db failed returning stations.");
                station = null;
            }
            if (station is null) throw new KeyNotFoundException("No Station with the given ID was found");
            IEnumerable<FlightHistoryDTO> flightHistories = station.History
                .OrderByDescending(fh => fh.EnterStationTime)
                .Skip(startFrom)
                .Take(paginationLimit)
                .Select(fh => FlightHistoryDTO.FromDBModel(fh));
            int totalHistory = station.History.Count;
            return new PaginatedDTO<FlightHistoryDTO> { Elements = flightHistories, Total = totalHistory };
        }

        /// <summary>
        /// Get all <see cref="Flight">Flights</see> which did not yet start the land/takeoff procedure.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Flight}"/> with waiting flights.</returns>
        private IEnumerable<Flight> GetWaitingFlights()
        {
            IEnumerable<Flight> flights;
            try
            {
                flights = flightRepository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Coudln't get flights from db");
                flights = Enumerable.Empty<Flight>();
            }
            return flights.Where(f => f.History.Count <= 0).OrderBy(f => f.PlannedTime);
        }
        /// <summary>
        /// Initialize the flights waiting to enter control towers.
        /// </summary>
        private void InitializeWaitingFlights()
        {
            IEnumerable<Flight> undeltFlights = GetWaitingFlights();
            foreach (Flight flight in undeltFlights)
            {
                try
                {
                    SendFlightToControlTowerAtTime(flight);
                }
                catch (KeyNotFoundException e)
                {
                    logger.LogCritical(e, "A flight was targeted to an non-existant control tower");
                }
            }
        }
        /// <summary>
        /// Initialize the flights currently at stations.
        /// </summary>
        private void InitializeFlightsFromStations()
        {
            IEnumerable<FlightHistory> currentlyInStationFlights = flightHistoryRepository
                .GetAll()
                .AsEnumerable()
                .GroupBy(fh => fh.StationId)
                .Where(grp => grp.All(fh => !fh.LeaveStationTime.HasValue))
                .Select(grp => grp.Last());
            stationTreeBuilder.ConnectExistingFlightsToStations(currentlyInStationFlights);
        }
        /// <summary>
        /// Hold the flights waiting untill it's there time to shine.
        /// </summary>
        /// <param name="flight">Flight to delay.</param>
        /// <exception cref="ArgumentNullException">Flight is null.</exception>
        /// <exception cref="KeyNotFoundException">Flight is aimed to a non existant control tower.</exception>
        private async void SendFlightToControlTowerAtTime(Flight flight)
        {
            if (flight is null)
                throw new ArgumentNullException(nameof(flight), "Flight must not be null, we are not Malaysia airlines!");
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            IControlTowerService controlTowerService = stationTreeBuilder[controlTowerName] ??
                throw new KeyNotFoundException("Control tower does not exist");
            TimeSpan delayUntillFlight = flight.PlannedTime - DateTime.Now;
            notifier.NotifyFutureFlightAdded(flight);
            if (delayUntillFlight > TimeSpan.Zero)
            {
                await Task.Delay(delayUntillFlight);
            }
            logger.LogInformation($"Flight completed waiting and is now moving to control tower {controlTowerName}");
            ILogger<IFlightService> flightLogger = loggerFactory.CreateLogger<IFlightService>();
            controlTowerService.FlightArrived(new FlightService(flight, flightLogger));
        }
        /// <summary>
        /// Build the station tree of all control towers and stations.
        /// </summary>
        private void CreateStationTrees()
        {
            try
            {
                IEnumerable<ControlTower> controlTowers = controlTowerRepository.GetAll();
                IEnumerable<Station> stations = stationRepository.GetAll();
                stationTreeBuilder.BuildStationsTree(controlTowers, stations);
            }
            catch (Exception e)
            {
                logger.LogError(e, "issues reading from db");
            }
        }
        /// <summary>
        /// Get all the waiting flights relevant for a control tower.
        /// </summary>
        /// <param name="controlTowerId">The ID of control tower to check for.</param>
        /// <param name="controlTowerName">The name of control tower to check for.</param>
        /// <returns>All waiting flights as a DTO</returns>
        private IEnumerable<FlightDTO> GetFlightDtos(Guid controlTowerId)
        {
            return flightRepository
                .GetAll()
                .AsEnumerable()
                .Where(f =>
                    f.ControlTowerId == controlTowerId &&
                    (f.History.Count <= 0 || f.History.Any(fh => !fh.LeaveStationTime.HasValue))
                )
                .Select(f => FlightDTO.FromDBModel(f));
        }
        /// <summary>
        /// Get all the station relations relevant for a control tower.
        /// </summary>
        /// <param name="stations">The stations of control tower.</param>
        /// <returns>All station relations as a DTO</returns>
        private IEnumerable<StationRelationDTO> GetStationRelationDtos(ICollection<Station> stations)
        {
            IEnumerable<StationRelation> stationRelations;
            try
            {
                stationRelations = stationRelationRepository.GetAll().AsEnumerable();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Issue getting stations from DB");
                stationRelations = Enumerable.Empty<StationRelation>();
            }
            return stationRelations
                .Where(sr => stations.Any(s => sr.StationFromId == s.Id))
                .Select(sr => StationRelationDTO.FromDBModel(sr));
        }
    }
}
