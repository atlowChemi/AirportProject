﻿using Common.DTO;
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

        public async Task<AirportDataDTO> RegisterToControlTowerAndGetData(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"CT-{name}");
            return airportService.GetAirportData(name);
        }

        public IEnumerable<Airplane> GetAirplanes()
        {
            return airportService.GetAirplanes();
        }

        public void FlightArrival(Flight flight)
        {
            airportService.HandleNewFlightArrivedAsync(flight);
        }
    }
}
