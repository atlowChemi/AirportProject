using Common.Interfaces;
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
        private readonly IAirportService airportService;

        public FlightHub(IAirportService airportService)
        {
            this.airportService = airportService;
        }
        public IEnumerable<Airplane> GetAirplanes()
        {
            var airplanes = airportService.GetAirplanes();
            return airplanes;
        }

        public Flight FlightArrival(Flight flight)
        {
            airportService.HandleNewFlightArrivedAsync(flight);
            return flight;
        }

        public void GetFlightData() { }
        public void GetStationsData() { }
    }
}
