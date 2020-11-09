using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Models
{
    class Station : IStation
    {
        public int Id { get; set; }
        public IAirplane Airplane { get; private set; }
        [NotMapped]
        public bool IsStationAvailable => Airplane == null;
        public string Name { get; set; }

        public virtual ICollection<IStation> TakeoffStations { get; set; }

        public virtual ICollection<IStation> LandingStations { get; set; }

        public event EventHandler AvailabiltyChange;

        public void PlaneArrived(IAirplane airplane)
        {
            Airplane = airplane;
            Airplane.StartWaitingInStation();
            Airplane.ReadyToContinue += Airplane_ReadyToContinue;
        }

        private void Airplane_ReadyToContinue(object sender, EventArgs e)
        {
            ICollection<IStation> nextStationListByDirection = Airplane.Direction == AirplaneDirection.Landing ?
                LandingStations : TakeoffStations;
            // There is no more stations to pass, plane can go bye bye.
            if (nextStationListByDirection.Count == 0)
            {
                Airplane = null;
                return;
            }
            // Attempt finding an available station, and if needed sign up to all.
            IStation nextFreeStation = nextStationListByDirection.FirstOrDefault(station => station.IsStationAvailable);
            if (nextFreeStation != null)
            {
                nextFreeStation.PlaneArrived(Airplane);
                Airplane = null;
            }
            else
            {
                foreach (Station station in nextStationListByDirection)
                {
                    station.AvailabiltyChange += NextStation_AvailabiltyChange;
                }
            }
        }

        private void NextStation_AvailabiltyChange(object sender, EventArgs e)
        {
            if (Airplane == null)
            {
                return;
            }
            if (sender is Station availableStation)
            {
                availableStation.PlaneArrived(Airplane);
                Airplane = null;
                // Unregister from all from all stations.
                ICollection<IStation> nextStationListByDirection = Airplane.Direction == AirplaneDirection.Landing ?
                LandingStations : TakeoffStations;
                foreach (Station station in nextStationListByDirection)
                {
                    station.AvailabiltyChange -= NextStation_AvailabiltyChange;
                }
            }
            else
            {
                throw new ArgumentException("Sender must be a station!", nameof(sender));
            }
        }
    }
}
