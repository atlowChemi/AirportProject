using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airplane> airplaneRepository;
        private readonly IRepository<Station> stationRepository;
        private readonly IRepository<ControlTower> controlTowerRepository;
        private readonly IStationTreeBuilderService stationTreeBuilder;

        public AirportService(IRepository<Airplane> airplaneRepository,
            IRepository<Station> stationRepository,
            IRepository<ControlTower> controlTowerRepository,
            IStationTreeBuilderService stationTreeBuilder)
        {
            this.airplaneRepository = airplaneRepository;
            this.stationRepository = stationRepository;
            this.controlTowerRepository = controlTowerRepository;
            this.stationTreeBuilder = stationTreeBuilder;

            CreateStationTrees();
        }


        public IEnumerable<Airplane> GetAirplanes() => airplaneRepository.GetAll();

        public async Task<Flight> HandleNewFlightArrivedAsync(Flight flight)
        {
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            IControlTowerService controlTowerService = stationTreeBuilder[controlTowerName] ?? 
                throw new ArgumentOutOfRangeException(nameof(flight), "Control tower does not exist");

            // TODO: Flight arrived should now be added to DB, and Should wait untill flight is ready to get to airport.
            await Task.Delay(new TimeSpan(0, 0, 10));
            return flight;
        }

        private void CreateStationTrees()
        {
            IEnumerable<ControlTower> controlTowers = controlTowerRepository.GetAll();
            IEnumerable<Station> stations = stationRepository.GetAll();
            stationTreeBuilder.BuildStationsTree(controlTowers, stations);
            //controlTowerServices = stationTreeBuilder.ControlTowerServices;
        }
    }
}
