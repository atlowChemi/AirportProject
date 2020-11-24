using Common.DTO;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airplane> airplaneRepository;
        private readonly IRepository<Station> stationRepository;
        private readonly IRepository<StationRelation> stationRelationRepository;
        private readonly IRepository<ControlTower> controlTowerRepository;
        private readonly IRepository<Flight> flightRepository;
        private readonly IStationTreeBuilderService stationTreeBuilder;
        private readonly IFutureFlightNotifier notifier;

        private static bool InitialCreate = true;

        public AirportService(IRepository<Airplane> airplaneRepository,
            IRepository<Station> stationRepository,
            IRepository<StationRelation> stationRelationRepository,
            IRepository<ControlTower> controlTowerRepository,
            IRepository<Flight> flightRepository,
            IStationTreeBuilderService stationTreeBuilder,
            INotifier notifier)
        {
            this.airplaneRepository = airplaneRepository;
            this.stationRepository = stationRepository;
            this.stationRelationRepository = stationRelationRepository;
            this.controlTowerRepository = controlTowerRepository;
            this.flightRepository = flightRepository;
            this.stationTreeBuilder = stationTreeBuilder;
            this.notifier = notifier;
            CreateStationTrees();
            if (InitialCreate) InitializeWaitingFlights();
        }


        public IEnumerable<Airplane> GetAirplanes() => airplaneRepository.GetAll();

        public AirportDataDTO GetAirportData(string name)
        {
            ControlTower controlTower = stationTreeBuilder[name]?.ControlTower ?? throw new ArgumentOutOfRangeException(nameof(name), "No control tower with given name found!");
            IEnumerable<FlightDTO> flights = flightRepository.GetAll().Where(f => f.History.Count <= 0 && (f.ControlTowerId == controlTower.Id || (f.ControlTower.Name == f.To && f.Direction == FlightDirection.Landing) || (f.ControlTower.Name == f.From && f.Direction == FlightDirection.Takeoff))).Select(f => new FlightDTO
            {
                AirplaneId = f.AirplaneId,
                ControlTowerId = f.ControlTowerId,
                Direction = f.Direction,
                From = f.From,
                Id = f.Id,
                PlannedTime = f.PlannedTime,
                StationId = f.StationId,
                To = f.To
            });
            IEnumerable<StationDTO> stations = controlTower.Stations.Select(s => new StationDTO
            {
                ControlTowerId = s.ControlTowerId,
                Id = s.Id,
                Name = s.Name
            });
            IEnumerable<StationRelationDTO> stationRelations = stationRelationRepository.GetAll().AsEnumerable().Where(sr => controlTower.Stations.Any(s => sr.StationFromId == s.Id)).Select(sr => new StationRelationDTO
            {
                Direction = sr.Direction,
                StationFromId = sr.StationFromId,
                StationToId = sr.StationToId
            });
            IEnumerable<StationControlTowerRelationDTO> firstStations = controlTower.FirstStations.Select(sctr => new StationControlTowerRelationDTO
            {
                ControlTowerId = sctr.ControlTowerId,
                Direction = sctr.Direction,
                StationToId = sctr.StationToId
            });
            ControlTowerDTO controlTowerDTO = new ControlTowerDTO { Name = name, Id = controlTower.Id };
            return new AirportDataDTO { ControlTower = controlTowerDTO, FirstStations = firstStations, Flights = flights, StationRelations = stationRelations, Stations = stations };
        }

        public async Task HandleNewFlightArrivedAsync(Flight flight)
        {
            Flight dbFlight = await flightRepository.AddAsync(flight);
            notifier.NotifyFutureFlightAdded(dbFlight);

            SendFlightToControlTowerAtTime(flight);
        }

        public IEnumerable<Flight> GetWaitingFlights()
        {
            return flightRepository.GetAll().Where(f => f.History.Count <= 0 && f.ControlTowerId == null).OrderBy(f => f.PlannedTime);
        }

        private void InitializeWaitingFlights()
        {
            InitialCreate = false;
            IEnumerable<Flight> undeltFlights = GetWaitingFlights();
            foreach (Flight flight in undeltFlights)
            {
                SendFlightToControlTowerAtTime(flight);
            }
        }

        private async void SendFlightToControlTowerAtTime(Flight flight)
        {
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            IControlTowerService controlTowerService = stationTreeBuilder[controlTowerName] ??
                throw new ArgumentOutOfRangeException(nameof(flight), "Control tower does not exist");
            TimeSpan delayUntillFlight = flight.PlannedTime - DateTime.Now;
            flight.ControlTowerId = controlTowerService.ControlTower.Id;
            Task<Flight> dbFlightTask = flightRepository.UpdateAsync(flight);
            if (delayUntillFlight > TimeSpan.Zero)
            {
                await Task.Delay(delayUntillFlight);
            }
            controlTowerService.FlightArrived(new FlightService(await dbFlightTask));
        }

        private void CreateStationTrees()
        {
            IEnumerable<ControlTower> controlTowers = controlTowerRepository.GetAll();
            IEnumerable<Station> stations = stationRepository.GetAll();
            stationTreeBuilder.BuildStationsTree(controlTowers, stations);
        }
    }
}
