using Common.Events;
using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    /// <summary>
    /// Service that can save changes to airport DB.
    /// </summary>
    public class AirportDBService : IAirportDBService
    {
        /// <summary>
        /// A scope factory to help this service (Singelton) to reach out to the Db (Scoped).
        /// </summary>
        private readonly IServiceScopeFactory serviceScopeFactory;
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IAirportDBService> logger;

        /// <summary>
        /// Generate a new instance of the Airport DB service.
        /// </summary>
        /// <param name="serviceScopeFactory">The scoping factory.</param>
        /// <param name="logger">The logger for this service.</param>
        public AirportDBService(IServiceScopeFactory serviceScopeFactory, ILogger<IAirportDBService> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory), "Service scope factory is required.");
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger is required.");
        }

        public async Task FlightMoved(FlightEventArgs flightEvent)
        {
            Flight flight = flightEvent.Flight;
            Station stationFrom = flightEvent.StationFrom;
            if (stationFrom is not null) stationFrom.CurrentFlightId = null;
            Station stationTo = flightEvent.StationTo;
            if (stationTo is not null) stationTo.CurrentFlightId = flight.Id;
            if (flightEvent.IsStationSelfInvoke)
            {
                return;
            }
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
            try
            {
                IRepository<Flight> flightRepo = scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
                IRepository<Station> stationRepo = scope.ServiceProvider.GetRequiredService<IRepository<Station>>();
                Task.WaitAll(
                    flightRepo.UpdateAsync(flight),
                    stationRepo.UpdateAsync(stationFrom),
                    stationRepo.UpdateAsync(stationTo)
                );
                await flightRepo.UpdateAsync(flight);
            }
            catch (InvalidOperationException e)
            {
                logger.LogError(e, "Error getting flight repository.");
            }
            catch (DbUpdateException e)
            {
                logger.LogError(e, "Error updating flight in repository.");
            }
            catch (Exception e)
            {
                logger.LogError(e, "Unknown exception while updating repository.");
            }
        }

        /// <summary>
        /// Open a new flight history row in DB when flight moved in to new station.
        /// </summary>
        /// <param name="flight">Flight that has moved.</param>
        /// <param name="to">Station the flight moved to.</param>
        private static void OpenFlightHistoryRow(Flight flight, Station to)
        {
            FlightHistory flightHistory = new FlightHistory { StationId = to.Id, EnterStationTime = DateTime.Now };
            if (flight.History is null)
            {
                flight.History = new List<FlightHistory>();
            }
            flight.History.Add(flightHistory);
        }
        /// <summary>
        /// Close an existing flight history row in DB when flight moved out of a station.
        /// </summary>
        /// <param name="flight">Flight that has moved.</param>
        /// <param name="from">Station the flight moved from.</param>
        private static void CloseFlighHistoryRow(Flight flight, Station from)
        {
            FlightHistory flightHistory = flight.History.FirstOrDefault(fh => fh.StationId == from.Id && !fh.LeaveStationTime.HasValue);
            if (flightHistory is not null) flightHistory.LeaveStationTime = DateTime.Now;
        }
        /// <summary>
        /// Close old row, and open a new one, since flight ledt a station, and entered a new one.
        /// </summary>
        /// <param name="flight">Flight that has moved.</param>
        /// <param name="from">Station the flight moved from.</param>
        /// <param name="to">Station the flight moved to.</param>
        private static void CloseFlighHistoryRowAndOpenNewOne(Flight flight, Station from, Station to)
        {
            CloseFlighHistoryRow(flight, from);
            OpenFlightHistoryRow(flight, to);
        }
    }
}
