using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models
{
    public class Station
    {
        private readonly ILazyLoader lazyLoader;

        public Station() { }
        public Station(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Guid? CurrentFlightId { get; set; }
        public virtual Flight CurrentFlight { get; set; }

        private StationControlTowerRelation controlTowerRelation;

        public virtual StationControlTowerRelation ControlTowerRelation
        {
            get => lazyLoader.Load(this, ref controlTowerRelation);
            set => controlTowerRelation = value;
        }


        private ICollection<StationRelation> parentStations;
        public virtual ICollection<StationRelation> ParentStations
        {
            get => lazyLoader.Load(this, ref parentStations);
            set => parentStations = value;
        }
        private ICollection<StationRelation> childrenStations;
        public virtual ICollection<StationRelation> ChildrenStations
        {
            get => lazyLoader.Load(this, ref childrenStations);
            set => childrenStations = value;
        }
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
