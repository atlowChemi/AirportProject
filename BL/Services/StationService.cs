using Common.Enums;
using Common.Events;
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

        public IEnumerable<IStationFlightHandler> LandingStations { get; private set; }

        public IEnumerable<IStationFlightHandler> TakeoffStations { get; private set; }

        public event EventHandler<FlightEventArgs> FlightChanged;


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
                if (CurrentFlight != null) return false;
                CurrentFlight = flight;
                CurrentFlight.StartWaitingInStationAsync(WaitingTimeMS);
                CurrentFlight.ReadyToContinue += CurrentFlight_ReadyToContinue;
                return true;
            }
        }

        private void CurrentFlight_ReadyToContinue(object sender, EventArgs e)
        {
            if (sender is not IFlightService) throw new ArgumentException("Sender must be a logical flight", nameof(sender));
            IEnumerable<IStationFlightHandler> nextStationListByDirection = CurrentFlight?.Flight.Direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
            // There are no more stations to pass, plane can go bye bye.
            if (nextStationListByDirection is null || !nextStationListByDirection.Any())
            {
                ChangeAvailability(null);
                return;
            }
            // Attempt finding an available station, and if needed sign up to all.
            IStationFlightHandler nextFreeStation = nextStationListByDirection.FirstOrDefault(station => station.IsHandlerAvailable);
            if (nextFreeStation is not null && nextFreeStation.FlightArrived(CurrentFlight))
            {
                ChangeAvailability(nextFreeStation.Station);
            }
            else
            {
                foreach (IStationFlightHandler station in nextStationListByDirection)
                {
                    station.FlightChanged += Next_Station_FlightChanged; ;
                }
            }
        }

        private void Next_Station_FlightChanged(object sender, EventArgs e)
        {
            if (CurrentFlight is null) return;

            // This was not called by a station, that's bad!
            if (sender is not IStationService availableStation)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));

            //If manages to move to next station, unsubscribe, otherwise wait for next available.
            if (availableStation.FlightArrived(CurrentFlight))
            {
                // Unregister from all from all stations.
                IEnumerable<IStationFlightHandler> nextStationListByDirection = CurrentFlight.Flight.Direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
                foreach (IStationFlightHandler station in nextStationListByDirection)
                {
                    station.FlightChanged -= Next_Station_FlightChanged;
                }
                ChangeAvailability(availableStation.Station);
            }

        }

        private void ChangeAvailability(Station stationTo)
        {
            Flight flight = CurrentFlight.Flight;
            CurrentFlight.ReadyToContinue -= CurrentFlight_ReadyToContinue;
            CurrentFlight = null;
            FlightChanged?.Invoke(this, new FlightEventArgs(flight, Station, stationTo));
        }

        private void AddCurrentFlightFromDB()
        {
            if (Station.CurrentFlight is not null)
            {
                FlightArrived(new FlightService(Station.CurrentFlight));
            }
        }
    }
}
