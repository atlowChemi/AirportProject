using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Models
{
    public class Station : IStation
    {
        public Guid Id { get; set; }

        public IFlight CurrentFlight { get; private set; }

        public bool IsStationAvailable => CurrentFlight == null;

        public string Name { get; set; }

        public ICollection<IStation> TakeoffStations { get; set; } = new List<IStation>();

        public ICollection<IStation> LandingStations { get; set; } = new List<IStation>();

        public int WaitingTimeMS { get; }

        public event EventHandler<EventArgs> AvailabiltyChange;

        public Station(int waitingTimeMS)
        {
            WaitingTimeMS = waitingTimeMS;
        }

        public bool FlightArrived(IFlight flight)
        {
            if (CurrentFlight != null) return false;
            CurrentFlight = flight;
            CurrentFlight.StartWaitingInStation(WaitingTimeMS);
            CurrentFlight.ReadyToContinue += CurrentFlight_ReadyToContinue;
            return true;
        }

        private void CurrentFlight_ReadyToContinue(object sender, EventArgs e)
        {
            ICollection<IStation> nextStationListByDirection = CurrentFlight.Direction == FlightDirection.Landing ?
                            LandingStations : TakeoffStations;
            // There is no more stations to pass, plane can go bye bye.
            if (nextStationListByDirection.Count == 0)
            {
                ChangeAvailability();
                return;
            }
            // Attempt finding an available station, and if needed sign up to all.
            IStation nextFreeStation = nextStationListByDirection.FirstOrDefault(station => station.IsStationAvailable);
            if (nextFreeStation != null)
            {
                nextFreeStation.FlightArrived(CurrentFlight);
                ChangeAvailability();
            }
            else
            {
                foreach (Station station in nextStationListByDirection)
                {
                    station.AvailabiltyChange += Next_Station_AvailabiltyChange; ;
                }
            }
        }

        private void Next_Station_AvailabiltyChange(object sender, EventArgs e)
        {
            if (CurrentFlight == null) return;

            // This was not called by a station, that's bad!
            if (!(sender is Station availableStation))
                throw new ArgumentException("Sender must be a station!", nameof(sender));

            //If manages to move to next station, unsubscribe, otherwise wait for next available.
            if (availableStation.FlightArrived(CurrentFlight))
            {
                // Unregister from all from all stations.
                ICollection<IStation> nextStationListByDirection = CurrentFlight.Direction == FlightDirection.Landing ?
                LandingStations : TakeoffStations;
                foreach (Station station in nextStationListByDirection)
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
