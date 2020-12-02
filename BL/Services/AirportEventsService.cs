using Common.Events;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    /// <summary>
    /// Service that registers to all relevant events and handels them.
    /// </summary>
    public class AirportEventsService : IAirportEventsService
    {
        /// <summary>
        /// The notifier to use in order to update the UI of changes.
        /// </summary>
        private readonly INotifier notifier;
        /// <summary>
        /// The DB service that should handle DB updates.
        /// </summary>
        private readonly IAirportDBService airportDBService;
        /// <summary>
        /// The changers to listen to.
        /// </summary>
        private IEnumerable<IFlightChanger> flightChangers = Enumerable.Empty<IFlightChanger>();

        /// <summary>
        /// Generate a new instance of the Airport Events service.
        /// </summary>
        /// <param name="notifier">The notifier to use fro UI updates.</param>
        /// <param name="airportDBService">The DB updater.</param>
        public AirportEventsService(INotifier notifier, IAirportDBService airportDBService)
        {
            this.notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
            this.airportDBService = airportDBService ?? throw new ArgumentNullException(nameof(airportDBService));
        }

        public void AddStationsToListenTo(IEnumerable<IFlightChanger> stationServices)
        {
            if (stationServices is null)
                throw new ArgumentNullException(nameof(stationServices), "services can't be null!");
            IEnumerable<IFlightChanger> newStations = stationServices.Where(fc => !flightChangers.Any(flc => fc == flc));
            foreach (IFlightChanger stationService in newStations)
            {
                stationService.FlightChanged += StationService_FlightChanged;
            }
            flightChangers = flightChangers.Concat(newStations);
        }

        /// <summary>
        /// Event handler for flight changes in the IFlightChanger.
        /// </summary>
        /// <param name="sender">The IFlightChanger that raised the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void StationService_FlightChanged(object sender, FlightEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));

            notifier.NotifyFlightChanges(e);
            airportDBService.FlightMoved(e);
        }
    }
}
