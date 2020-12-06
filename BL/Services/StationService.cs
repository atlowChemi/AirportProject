using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    /// <summary>
    /// Logical wrapper of a station.
    /// </summary>
    public class StationService : IStationService
    {
        /// <summary>
        /// Enable locking multi-threads, to avoid Malaysian issues.
        /// </summary>
        private readonly object lockObj = new object();
        /// <summary>
        /// The logger factory for this service.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IStationService> logger;

        public Station Station { get; }
        public IFlightService CurrentFlight { get; private set; }
        public int WaitingTimeMS { get; }

        public bool IsHandlerAvailable => CurrentFlight == null;
        public IEnumerable<IRelatedToStation> NextStations => Station?.ChildrenStations;

        public IEnumerable<IStationFlightHandler> LandingStations { get; private set; }

        public IEnumerable<IStationFlightHandler> TakeoffStations { get; private set; }

        public event EventHandler<FlightEventArgs> FlightChanged;

        /// <summary>
        /// Generate a new instance of the station service.
        /// </summary>
        /// <param name="station">The station this instance should handle.</param>
        /// <param name="waitingTimeMS">The amount of time the flights should wait in this station.</param>
        /// <param name="loggerFactory">The logger factory for this service.</param>
        /// <exception cref="ArgumentOutOfRangeException">Waiting time is a negative time.</exception>
        /// <exception cref="ArgumentNullException">Station to hande is null.</exception>
        public StationService(Station station, int waitingTimeMS, ILoggerFactory loggerFactory)
        {
            if (waitingTimeMS <= 0) throw new ArgumentOutOfRangeException(nameof(waitingTimeMS), "Station can't wait less than 1 MS!");
            Station = station ?? throw new ArgumentNullException(nameof(station), "Cannot create service for null station!");
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            WaitingTimeMS = waitingTimeMS;
            logger = loggerFactory.CreateLogger<IStationService>();
        }

        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations)
        {
            SignOutOfAllStationsEvents();
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
            SignupToAllStationsEvents();
            logger.LogInformation("Station was connected to its next stations.");
        }

        public bool FlightArrived(IFlightService flight, bool fromDb = false)
        {
            lock (lockObj)
            {
                if (CurrentFlight is not null)
                {
                    logger.LogWarning($"Attempted to push flight {flight.Flight.Id} in a busy station - {Station.Id}.");
                    return false;
                }
                CurrentFlight = flight;
                if (fromDb)
                    FlightChanged?.Invoke(this, new(Station.CurrentFlight, Station, Station));
                CurrentFlight.StartWaitingInStationAsync(WaitingTimeMS);
                CurrentFlight.ReadyToContinue += CurrentFlight_ReadyToContinue;
                logger.LogWarning($"Pushed flight {flight.Flight.Id} in to station {Station.Id}.");
                return true;
            }
        }

        /// <summary>
        /// Event handler to handle the situation when the flight has completed it's tasks in the station and is ready to continue.
        /// </summary>
        /// <param name="sender">The flight that has raised the event.</param>
        /// <param name="e">The arguments of the event.</param>
        /// <exception cref="ArgumentException">The sender who raised this event is not ctuallt a flight.</exception>
        private void CurrentFlight_ReadyToContinue(object sender, EventArgs e)
        {
            logger.LogInformation($"Flight {CurrentFlight.Flight.Id} is ready to move out of station {Station.Id}");
            if (sender is not IFlightService) throw new ArgumentException("Sender must be a logical flight", nameof(sender));
            IEnumerable<IStationFlightHandler> nextStationList = GetNextStationListByDirection(CurrentFlight.Flight.Direction);
            // There are no more stations to pass, plane can go bye bye.
            if (nextStationList is null || !nextStationList.Any())
            {
                logger.LogInformation($"Flight {CurrentFlight.Flight.Id} finished its journey.");
                ChangeAvailability(null);
                return;
            }
            // Attempt finding an available station.
            IStationFlightHandler nextFreeStation = nextStationList.FirstOrDefault(station => station.IsHandlerAvailable);
            if (nextFreeStation is not null && nextFreeStation.FlightArrived(CurrentFlight))
            {
                logger.LogInformation($"Flight {CurrentFlight.Flight.Id} moved to station {nextFreeStation.Station.Id}.");
                ChangeAvailability(nextFreeStation.Station);
            }
        }
        /// <summary>
        /// Event handler to handle the situation where one of the next stations has turned available.
        /// </summary>
        /// <param name="sender">The station which has raised this event.</param>
        /// <param name="e">The arguments of the event.</param>
        /// <exception cref="ArgumentException">Sender of the event was not a station.</exception>
        private void Next_Station_FlightChanged(object sender, EventArgs e)
        {
            if (CurrentFlight is null || !CurrentFlight.IsReadyToContinue) return;

            // This was not called by a station, that's bad!
            if (sender is not IStationFlightHandler availableStation)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));
            //Make sure the station goes to the flights direction.
            IEnumerable<IStationFlightHandler> stations = GetNextStationListByDirection(CurrentFlight.Flight.Direction);
            bool IsStationInTheFlightDirection = stations.Contains(availableStation);
            if (!IsStationInTheFlightDirection) return;

            //If manages to move to next station, otherwise wait for next available.
            if (availableStation.IsHandlerAvailable && availableStation.FlightArrived(CurrentFlight))
            {
                ChangeAvailability(availableStation.Station);
            }

        }
        /// <summary>
        /// Change the availability of the station.
        /// </summary>
        /// <param name="stationTo">The station the flight has moved to.</param>
        private void ChangeAvailability(Station stationTo)
        {
            Flight flight = CurrentFlight.Flight;
            CurrentFlight.ReadyToContinue -= CurrentFlight_ReadyToContinue;
            CurrentFlight = null;
            FlightChanged?.Invoke(this, new FlightEventArgs(flight, Station, stationTo));
        }
        /// <summary>
        /// Get the relevant Flight handlers.
        /// </summary>
        /// <param name="direction">The direction to get the flight handlers for.</param>
        /// <returns>A <see cref="IEnumerable{IStationFlightHandler}"/> of the next stations.</returns>
        private IEnumerable<IStationFlightHandler> GetNextStationListByDirection(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;

        /// <summary>
        /// Remove listeners from all the stations, in order to replace them.
        /// </summary>
        private void SignOutOfAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged -= Next_Station_FlightChanged;
            }
        }
        /// <summary>
        /// Start listening to all the stations, in order to transfer flights if a station has turned available.
        /// </summary>
        private void SignupToAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged += Next_Station_FlightChanged;
            }
        }
    }
}
