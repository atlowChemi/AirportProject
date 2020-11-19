using Common.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ControlTower
    {
        private readonly ILazyLoader lazyLoader;

        public ControlTower() { }
        public ControlTower(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }


        public Guid Id { get; set; }
        public string Name { get; set; }

        private ICollection<StationControlTowerRelation> firstStations;
        public virtual ICollection<StationControlTowerRelation> FirstStations
        {
            get => lazyLoader.Load(this, ref firstStations);
            set => firstStations = value;
        }

        private ICollection<Flight> flightsWaiting;
        public virtual ICollection<Flight> FlightsWaiting
        {
            get => lazyLoader.Load(this, ref flightsWaiting);
            set => flightsWaiting = value;
        }
    }
}
