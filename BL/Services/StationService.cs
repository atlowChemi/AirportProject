using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class StationService : IStationService
    {
        private readonly object lockObj = new object();
        public Station Station { get; }
        public IFlightService CurrentFlight { get; private set; }
        public int WaitingTimeMS { get; }

        public bool IsHandlerAvailable => CurrentFlight == null;
        public IEnumerable<IRelatedToStation> NextStations => Station?.ChildrenStations;

        public IEnumerable<IFlightHandler> LandingStations { get; private set; }

        public IEnumerable<IFlightHandler> TakeoffStations { get; private set; }

        public event EventHandler<EventArgs> AvailabiltyChange;


        public StationService(Station station, int waitingTimeMS)
        {
            if (waitingTimeMS <= 0) throw new ArgumentOutOfRangeException(nameof(waitingTimeMS), "Station can't wait less than 1 MS!");
            Station = station ?? throw new ArgumentNullException(nameof(station), "Cannot create service for null station!");
            WaitingTimeMS = waitingTimeMS;
        }

        public void ConnectToNextStations(IEnumerable<IFlightHandler> landingStations, IEnumerable<IFlightHandler> takeoffStations)
        {
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
        }

        public bool FlightArrived(IFlightService flight)
        {
            lock (lockObj)
            {
                if (CurrentFlight != null) return false;
                CurrentFlight = flight;
                CurrentFlight.StartWaitingInStationAsync(WaitingTimeMS);
                CurrentFlight.ReadyToContinue += CurrentFlight_ReadyToContinue;
                return true;
            }
        }

        private void CurrentFlight_ReadyToContinue(object sender, EventArgs e)
        {
            IEnumerable<IFlightHandler> nextStationListByDirection = CurrentFlight.Flight.Direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
            // There are no more stations to pass, plane can go bye bye.
            if (nextStationListByDirection == null || !nextStationListByDirection.Any())
            {
                ChangeAvailability();
                return;
            }
            // Attempt finding an available station, and if needed sign up to all.
            IFlightHandler nextFreeStation = nextStationListByDirection.FirstOrDefault(station => station.IsHandlerAvailable);
            if (nextFreeStation != null && nextFreeStation.FlightArrived(CurrentFlight))
            {
                ChangeAvailability();
            }
            else
            {
                foreach (IFlightHandler station in nextStationListByDirection)
                {
                    station.AvailabiltyChange += Next_Station_AvailabiltyChange; ;
                }
            }
        }

        private void Next_Station_AvailabiltyChange(object sender, EventArgs e)
        {
            if (CurrentFlight is null) return;

            // This was not called by a station, that's bad!
            if (sender is not IStationService availableStation)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));

            //If manages to move to next station, unsubscribe, otherwise wait for next available.
            if (availableStation.FlightArrived(CurrentFlight))
            {
                // Unregister from all from all stations.
                IEnumerable<IFlightHandler> nextStationListByDirection = CurrentFlight.Flight.Direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
                foreach (IFlightHandler station in nextStationListByDirection)
                {
                    station.AvailabiltyChange -= Next_Station_AvailabiltyChange;
                }
                ChangeAvailability();
            }

        }

        private void ChangeAvailability()
        {
            CurrentFlight = null;
            AvailabiltyChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
