using Common.Events;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class AirportEventsService : IAirportEventsService
    {
        private readonly INotifier notifier;
        private readonly IAirportDBService airportDBService;

        private IEnumerable<IFlightChanger> flightChangers = Enumerable.Empty<IFlightChanger>();

        public AirportEventsService(INotifier notifier, IAirportDBService airportDBService)
        {
            this.notifier = notifier;
            this.airportDBService = airportDBService;
        }

        public void AddStationsToListenTo(IEnumerable<IFlightChanger> stationServices)
        {
            IEnumerable<IFlightChanger> newStations = stationServices.Where(fc => !this.flightChangers.Any(flc => fc == flc));
            foreach (IFlightChanger stationService in newStations)
            {
                stationService.FlightChanged += StationService_FlightChanged;
            }
            flightChangers = flightChangers.Concat(newStations);
        }

        private void StationService_FlightChanged(object sender, FlightEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));

            notifier.NotifyFlightChanges(e);
            airportDBService.FlightMoved(e);
        }
    }
}
