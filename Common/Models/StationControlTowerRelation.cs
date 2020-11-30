using Common.Enums;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Common.Models
{
    /// <summary>
    /// The relationship between a <see cref="Models.Station">station</see> and a <see cref="Models.ControlTower">control tower</see>.
    /// </summary>
    public class StationControlTowerRelation : IRelatedToStation
    {
        /// <summary>
        /// The lazy loading handler.
        /// </summary>
        private readonly ILazyLoader lazyLoader;

        /// <summary>
        /// Create a new instance of a Control Tower Station relation.
        /// </summary>
        public StationControlTowerRelation() { }
        /// <summary>
        /// Create a new instance of a Control Tower Station relation.
        /// </summary>
        /// <param name="lazyLoader">Lazy loader to use through out the model.</param>
        public StationControlTowerRelation(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        /// <summary>
        /// The <see cref="FlightDirection">direction</see> the flights can arrive to this station.
        /// </summary>
        public FlightDirection Direction { get; set; }

        /// <summary>
        /// The ID of the <see cref="Models.Station">Station</see> which is related to the <see cref="Models.ControlTower">control tower</see>.
        /// </summary>
        public virtual Guid StationToId { get; set; }
        /// <summary>
        /// The <see cref="Models.Station">Station</see> which is related to the <see cref="Models.ControlTower">control tower</see>.
        /// </summary>
        private Station station;
        /// <summary>
        /// The <see cref="Models.Station">Station</see> which is related to the <see cref="Models.ControlTower">control tower</see>.
        /// </summary>
        public virtual Station Station
        {
            get => lazyLoader.Load(this, ref station);
            set => station = value;
        }
        
        /// <summary>
        /// The ID of the <see cref="Models.ControlTower">control tower</see> related to the <see cref="Station">Station</see>
        /// </summary>
        public virtual Guid ControlTowerId { get; set; }
        /// <summary>
        /// The ID of the <see cref="Models.ControlTower">control tower</see> related to the <see cref="Station">Station</see>
        /// </summary>
        public virtual ControlTower ControlTower { get; set; }
    }
}
