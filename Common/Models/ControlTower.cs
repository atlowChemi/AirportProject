using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ControlTower
    {
        public Guid Id { get; set; }

        public virtual ICollection<StationControlTowerRelation> FirstStations { get; set; }

        public virtual ICollection<Flight> FlightsWaiting { get; set; }
    }
}
