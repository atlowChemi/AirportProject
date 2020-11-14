using Common.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class FlightHub : Hub
    {
        public ICollection<Airplane> GetAirplanes()
        {
            return new Airplane[]{ new Airplane(), new Airplane(), new Airplane() };
        }

        public Flight CreateFlight(Flight flight)
        {
            return flight;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
