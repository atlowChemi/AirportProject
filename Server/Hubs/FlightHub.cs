using Common.DTO;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
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

        public IEnumerable<AirplaneDTO> GetAirplanes()
        {
            return airportService.GetAirplanes();
        }

        public PaginatedDTO<FlightHistoryDTO> GetStationFlightHistory(Guid stationId, int startFrom = 0, int paginationLimit = 15)
        {
            return airportService.GetStationHistory(stationId, startFrom, paginationLimit);
        }

        public void FlightArrival(Flight flight)
        {
            airportService.HandleNewFlightArrivedAsync(flight);
        }
    }
}
