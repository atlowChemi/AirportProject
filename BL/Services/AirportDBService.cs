using Common.Events;
using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AirportDBService : IAirportDBService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public AirportDBService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task FlightMoved(FlightEventArgs flightEvent)
        {
            Flight flight = flightEvent.Flight;
            if (flightEvent.IsFromControlTowerToFirstStation)
            {
                OpenFlightHistoryRow(flight, flightEvent.StationTo);
            }
            else if (flightEvent.IsFromLastStationToEnd)
            {
                CloseFlighHistoryRow(flight, flightEvent.StationFrom);
            }
            else
            {
                CloseFlighHistoryRowAndOpenNewOne(flight, flightEvent.StationFrom, flightEvent.StationTo);
            }
            flight.StationId = flightEvent.StationTo?.Id;
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            IRepository<Flight> repo = scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
            await repo.UpdateAsync(flight);
        }

        private static void OpenFlightHistoryRow(Flight flight, Station to)
        {
            FlightHistory flightHistory = new FlightHistory { StationId = to.Id, EnterStationTime = DateTime.Now };
            if (flight.History is null)
            {
                flight.History = new List<FlightHistory>();
            }
            flight.History.Add(flightHistory);
        }

        private static void CloseFlighHistoryRow(Flight flight, Station from)
        {
            FlightHistory flightHistory = flight.History.FirstOrDefault(fh => fh.StationId == from.Id && !fh.LeaveStationTime.HasValue);
            if (flightHistory is not null) flightHistory.LeaveStationTime = DateTime.Now;
        }

        private static void CloseFlighHistoryRowAndOpenNewOne(Flight flight, Station from, Station to)
        {
            CloseFlighHistoryRow(flight, from);
            OpenFlightHistoryRow(flight, to);
        }
    }
}
