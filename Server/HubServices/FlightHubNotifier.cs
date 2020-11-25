using Common.DTO;
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
            FlightDTO flightDto = new FlightDTO
            {
                AirplaneId = flight.AirplaneId,
                ControlTowerId = flight.ControlTowerId,
                Direction = flight.Direction,
                From = flight.From,
                Id = flight.Id,
                PlannedTime = flight.PlannedTime,
                StationId = flight.StationId,
                To = flight.To
            };
            StationDTO fromDto = null, toDto = null;
            Station from = e.StationFrom;
            if (from is not null)
                fromDto = new StationDTO { ControlTowerId = from.ControlTowerId, Id = from.Id, Name = from.Name };
            Station to = e.StationTo;
            if (to is not null)
                toDto = new StationDTO { ControlTowerId = to.ControlTowerId, Id = to.Id, Name = to.Name };
            hubContext.Clients.Group($"CT-{e.Flight.ControlTower.Name}").SendAsync("FlightMoved", flightDto, fromDto, toDto);
        }

        public void NotifyFutureFlightAdded(Flight flight)
        {
            string controlTowerName = flight.Direction == FlightDirection.Landing ? flight.To : flight.From;
            hubContext.Clients.Group($"CT-{controlTowerName}").SendAsync("FutureFlightAdded", flight);
        }
    }
}
