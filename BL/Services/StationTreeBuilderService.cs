using Common.Interfaces;
using Common.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Common.Enums;
using Common.Constants;

namespace BL.Services
{
    public class StationTreeBuilderService : IStationTreeBuilderService
    {
        private readonly object builderLock = new object();
        private readonly IRandomDataGeneratorService randomDataGeneratorService;
        private readonly IAirportEventsService airportEventsService;
        private ICollection<IStationService> stationServices;
        private ICollection<IControlTowerService> controlTowerServices;

        public IControlTowerService this[string name] => controlTowerServices?.FirstOrDefault(cst => cst.ControlTower.Name == name);

        public StationTreeBuilderService(IRandomDataGeneratorService randomDataGeneratorService, IAirportEventsService airportEventsService)
        {
            this.randomDataGeneratorService = randomDataGeneratorService;
            this.airportEventsService = airportEventsService;
        }

        public void BuildStationsTree(IEnumerable<ControlTower> controlTowers, IEnumerable<Station> stations)
        {
            if (controlTowers is null) throw new ArgumentNullException(nameof(controlTowers));
            if (stations is null) throw new ArgumentNullException(nameof(stations));

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
                    ConnectControlTowersWithStationRelations();
                    ConnectStationsWithStationRelations();

                    IEnumerable<IFlightChanger> flightChangers = stationServices.AsEnumerable<IFlightChanger>().Concat(controlTowerServices);
                    airportEventsService.AddStationsToListenTo(flightChangers);
                }
            }
        }

        /// <summary>
        /// Create new Service for each of the control towers.
        /// </summary>
        /// <returns>True if any controlTower was added</returns>
        private bool BuildControlTowerServicesForAllControlTowers(IEnumerable<ControlTower> controlTowers)
        {
            bool response = false;
            foreach (ControlTower controlTower in controlTowers)
            {
                response = true;
                controlTowerServices.Add(new ControlTowerService(controlTower));
            }
            return response;
        }

        /// <summary>
        /// Create new Service for each of the stations.
        /// </summary>
        private bool BuildStationServiceForAllStations(IEnumerable<Station> stations)
        {
            bool response = false;
            foreach (Station station in stations)
            {
                response = true;
                int waitingTimeMS = randomDataGeneratorService.CreateRandomNumber(
                    Constants.MINIMAL_STATION_DELAY,
                    Constants.MAXIMAL_STATION_DELAY);
                StationService stationService = new StationService(station, waitingTimeMS);
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
