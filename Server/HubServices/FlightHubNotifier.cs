using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;

namespace Server.HubServices
{
    public class FlightHubNotifier : INotifier
    {
        private readonly IHubContext<FlightHub> hubContext;

        public FlightHubNotifier(IHubContext<FlightHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public void NotifyFlightChanges(FlightEventArgs e)
        {
            Flight flight = e.Flight;
            Station from = e.StationFrom;
            Station to = e.StationTo;
            hubContext.Clients.Group($"CT-{e.Flight.ControlTower.Name}").SendAsync("FlightMoved", flight, from, to);
        }

        public void NotifyFutureFlightAdded(Flight flight)
        {
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            hubContext.Clients.Group($"CT-{controlTowerName}").SendAsync("FutureFlightAdded", flight);
        }
    }
}
