using Common.Enums;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Common.Models
{
    public class StationControlTowerRelation : IRelatedToStation
    {
        private readonly ILazyLoader lazyLoader;
        private Station station;

        public StationControlTowerRelation() { }
        public StationControlTowerRelation(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public FlightDirection Direction { get; set; }

        public virtual Guid StationToId { get; set; }
        public virtual Station Station
        {
            get => lazyLoader.Load(this, ref station);
            set => station = value;
        }
        public virtual Guid ControlTowerId { get; set; }
        public virtual ControlTower ControlTower { get; set; }
    }
}
