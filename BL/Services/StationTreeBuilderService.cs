using Common.Interfaces;
using Common.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Common.Enums;
using Common.Constants;
using Microsoft.Extensions.Logging;

namespace BL.Services
{
    /// <summary>
    /// Service that builds logical services for <see cref="ControlTower">Control Towers</see> and <see cref="Station">Stations</see> and connects them by the <see cref="StationRelation"/>.
    /// </summary>
    public class StationTreeBuilderService : IStationTreeBuilderService
    {
        /// <summary>
        /// Enable locking multi-threads, to avoid Malaysian issues.
        /// </summary>
        private readonly object builderLock = new object();
        /// <summary>
        /// The random data generator.
        /// </summary>
        private readonly IRandomDataGeneratorService randomDataGeneratorService;
        /// <summary>
        /// The airport event service to add all stations to.
        /// </summary>
        private readonly IAirportEventsService airportEventsService;
        /// <summary>
        /// The logger factory for this service.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IStationTreeBuilderService> logger;

        /// <summary>
        /// All station services.
        /// </summary>
        private ICollection<IStationService> stationServices;
        /// <summary>
        /// All control tower services.
        /// </summary>
        private ICollection<IControlTowerService> controlTowerServices;

        public bool WasInitialized { get; private set; } = false;

        public IControlTowerService this[string name] => controlTowerServices?.FirstOrDefault(cst => cst.ControlTower.Name == name);

        /// <summary>
        /// Generate a new instance of the station tree builder service.
        /// </summary>
        /// <param name="randomDataGeneratorService">The random data genrator to use.</param>
        /// <param name="airportEventsService">The airport event service to use.</param>
        /// <param name="loggerFactory">The logger factory to use.</param>
        public StationTreeBuilderService(IRandomDataGeneratorService randomDataGeneratorService,
                                         IAirportEventsService airportEventsService,
                                         ILoggerFactory loggerFactory)
        {
            this.randomDataGeneratorService = randomDataGeneratorService ?? throw new ArgumentNullException(nameof(randomDataGeneratorService));
            this.airportEventsService = airportEventsService ?? throw new ArgumentNullException(nameof(airportEventsService));
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            logger = loggerFactory.CreateLogger<IStationTreeBuilderService>();
        }

        public void BuildStationsTree(IEnumerable<ControlTower> controlTowers, IEnumerable<Station> stations)
        {
            if (controlTowers is null) throw new ArgumentNullException(nameof(controlTowers));
            if (stations is null) throw new ArgumentNullException(nameof(stations));

            logger.LogInformation("Start building station tree.");

            lock (builderLock)
            {
                if (controlTowerServices is null) controlTowerServices = new List<IControlTowerService>();
                if (stationServices is null) stationServices = new List<IStationService>();

                IEnumerable<ControlTower> newControlTowers = controlTowers.Where(ct => controlTowerServices.All(cts => cts.ControlTower.Id != ct.Id));
                IEnumerable<Station> newStations = stations.Where(s => stationServices.All(ss => ss.Station.Id != s.Id));

                bool isNewControlTower = BuildControlTowerServicesForAllControlTowers(newControlTowers);
                bool isNewStations = BuildStationServiceForAllStations(newStations);

                if (isNewControlTower || isNewStations)
                {
                    logger.LogInformation("Added new control towers / stations. currently rebuilding all connections.");
                    ConnectControlTowersWithStationRelations();
                    ConnectStationsWithStationRelations();

                    IEnumerable<IFlightChanger> flightChangers = stationServices.AsEnumerable<IFlightChanger>().Concat(controlTowerServices);
                    airportEventsService.AddStationsToListenTo(flightChangers);
                }
            }
        }

        public void ConnectExistingFlightsToStations(IEnumerable<FlightHistory> flights)
        {
            WasInitialized = true;
            foreach (FlightHistory fh in flights)
            {
                IStationService stationService = stationServices.FirstOrDefault(ss => ss.Station.Id == fh.StationId);

                if (stationService is null)
                {
                    logger.LogError($"Flight {fh.FlightId} is connected to a non existing station!");
                    throw new KeyNotFoundException("Invlid Flight!");
                }
                ILogger<IFlightService> flLogger = loggerFactory.CreateLogger<IFlightService>();
                IFlightService flightService = new FlightService(fh.Flight, flLogger);
                stationService.FlightArrived(flightService);
            }
        }

        /// <summary>
        /// Create new Service for each of the control towers.
        /// </summary>
        /// <returns>True if any controlTower was added.</returns>
        private bool BuildControlTowerServicesForAllControlTowers(IEnumerable<ControlTower> controlTowers)
        {
            bool response = false;
            foreach (ControlTower controlTower in controlTowers)
            {
                response = true;
                controlTowerServices.Add(new ControlTowerService(controlTower, loggerFactory));
            }
            return response;
        }

        /// <summary>
        /// Create new Service for each of the stations.
        /// </summary>
        /// <returns>True if any Station was added.</returns>
        private bool BuildStationServiceForAllStations(IEnumerable<Station> stations)
        {
            bool response = false;
            foreach (Station station in stations)
            {
                response = true;
                int waitingTimeMS = randomDataGeneratorService.CreateRandomNumber(
                    Constants.MINIMAL_STATION_DELAY,
                    Constants.MAXIMAL_STATION_DELAY);
                StationService stationService = new StationService(station, waitingTimeMS, loggerFactory);
                stationServices.Add(stationService);
            }
            return response;
        }

        /// <summary>
        /// Connect all of the stations with their relations.
        /// </summary>
        private void ConnectControlTowersWithStationRelations()
        {
            foreach (IControlTowerService controlTowerService in controlTowerServices)
                BuildConnections(controlTowerService);
        }
        /// <summary>
        /// Connect all of the stations with their relations.
        /// </summary>
        private void ConnectStationsWithStationRelations()
        {
            foreach (IStationService stationService in stationServices)
                BuildConnections(stationService);
        }

        /// <summary>
        /// Build the actual connections for landing / takingOff,
        /// and connect them to the hasNextConnection element.
        /// </summary>
        /// <param name="hasNextStations">An element which should have it's next connections connected.</param>
        private void BuildConnections(IHasNextStations hasNextStations)
        {
            IEnumerable<IStationService> landingStations = hasNextStations.NextStations
                .Where(sctr => sctr.Direction == FlightDirection.Landing)
                .Join(stationServices, sr => sr.StationToId, ss => ss.Station.Id, (sctr, ss) => ss);
            IEnumerable<IStationService> takeoffStations = hasNextStations.NextStations
                .Where(sctr => sctr.Direction == FlightDirection.Takeoff)
                .Join(stationServices, sr => sr.StationToId, ss => ss.Station.Id, (sctr, ss) => ss);
            hasNextStations.ConnectToNextStations(landingStations, takeoffStations);
        }
    }
}
