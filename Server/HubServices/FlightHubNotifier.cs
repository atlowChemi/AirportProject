using Common.DTO;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using System;

namespace Server.HubServices
{
    public class FlightHubNotifier : INotifier
    {
        /// <summary>
        /// The context of the flight hub.
        /// </summary>
        private readonly IHubContext<FlightHub> hubContext;

        /// <summary>
        /// Generate a new instance of the flight hub notifier.
        /// </summary>
        /// <param name="hubContext">The hub context to use.</param>
        public FlightHubNotifier(IHubContext<FlightHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public void NotifyFlightChanges(FlightEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e), "The event args are required");
            Flight flight = e.Flight;

            FlightDTO flightDto = FlightDTO.FromDBModel(flight);
            StationDTO fromDto = null, toDto = null;
            Station from = e.StationFrom;
            if (from is not null)
                fromDto = StationDTO.FromDBModel(from);
            Station to = e.StationTo;
            if (to is not null)
                toDto = StationDTO.FromDBModel(to);
            hubContext.Clients.Group($"CT-{e.Flight.ControlTower.Name}").SendAsync("FlightMoved", flightDto, fromDto, toDto);
        }

        public void NotifyFutureFlightAdded(Flight flight)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "Flight is required");
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            FlightDTO flightDto = FlightDTO.FromDBModel(flight);
            hubContext.Clients.Group($"CT-{controlTowerName}").SendAsync("FutureFlightAdded", flightDto);
        }
    }
}
