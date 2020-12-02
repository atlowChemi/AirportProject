using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
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
        /// <exception cref="ArgumentOutOfRangeException">Waiting time is a negative time.</exception>
        /// <exception cref="ArgumentNullException">Station to hande is null.</exception>
        public StationService(Station station, int waitingTimeMS)
        {
            if (waitingTimeMS <= 0) throw new ArgumentOutOfRangeException(nameof(waitingTimeMS), "Station can't wait less than 1 MS!");
            Station = station ?? throw new ArgumentNullException(nameof(station), "Cannot create service for null station!");
            WaitingTimeMS = waitingTimeMS;
            AddCurrentFlightFromDB();
        }

        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations)
        {
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
        }

        public bool FlightArrived(IFlightService flight)
        {
            lock (lockObj)
            {
                if (CurrentFlight is not null) return false;
                CurrentFlight = flight;
                CurrentFlight.StartWaitingInStationAsync(WaitingTimeMS);
                CurrentFlight.ReadyToContinue += CurrentFlight_ReadyToContinue;
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
            if (sender is not IFlightService) throw new ArgumentException("Sender must be a logical flight", nameof(sender));
            IEnumerable<IStationFlightHandler> nextStationList = GetNextStationListByDirection(CurrentFlight.Flight.Direction);
            // There are no more stations to pass, plane can go bye bye.
            if (nextStationList is null || !nextStationList.Any())
            {
                ChangeAvailability(null);
                return;
            }
            // Attempt finding an available station, and if needed sign up to all.
            IStationFlightHandler nextFreeStation = nextStationList.FirstOrDefault(station => station.IsHandlerAvailable);
            if (nextFreeStation is not null && nextFreeStation.FlightArrived(CurrentFlight))
            {
                ChangeAvailability(nextFreeStation.Station);
            }
            else
            {
                foreach (IStationFlightHandler station in nextStationList)
                {
                    station.FlightChanged += Next_Station_FlightChanged; ;
                }
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
            if (CurrentFlight is null) return;

            // This was not called by a station, that's bad!
            if (sender is not IStationFlightHandler availableStation)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));

            //If manages to move to next station, unsubscribe, otherwise wait for next available.
            if (availableStation.IsHandlerAvailable && availableStation.FlightArrived(CurrentFlight))
            {
                // Unregister from all from all stations.
                IEnumerable<IStationFlightHandler> nextStations = GetNextStationListByDirection(CurrentFlight.Flight.Direction);
                foreach (IStationFlightHandler station in nextStations)
                {
                    station.FlightChanged -= Next_Station_FlightChanged;
                }
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
        /// Populate the current flight which is in DB - if such exists.
        /// </summary>
        private void AddCurrentFlightFromDB()
        {
            if (Station.CurrentFlight?.History?.Any(h => h.Station.Id == Station.Id && !h.LeaveStationTime.HasValue) ?? false)
            {
                FlightArrived(new FlightService(Station.CurrentFlight));
                FlightChanged?.Invoke(this, new(Station.CurrentFlight, Station, Station));
            }
        }
        /// <summary>
        /// Get the relevant Flight handlers.
        /// </summary>
        /// <param name="direction">The direction to get the flight handlers for.</param>
        /// <returns>A <see cref="IEnumerable{IStationFlightHandler}"/> of the next stations.</returns>
        private IEnumerable<IStationFlightHandler> GetNextStationListByDirection(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
    }
}
