using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// A control tower from DB
    /// </summary>
    public class ControlTower
    {
        /// <summary>
        /// The lazy loading handler.
        /// </summary>
        private readonly ILazyLoader lazyLoader;

        /// <summary>
        /// Create a new instance of a Control Tower.
        /// </summary>
        public ControlTower() { }
        /// <summary>
        /// Create a new instance of a Control Tower.
        /// </summary>
        /// <param name="lazyLoader">Lazy loader to use through out the model.</param>
        public ControlTower(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        /// <summary>
        /// ID of the Control Tower.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Name of the Control Tower.
        /// </summary>
        /// <example>TLV</example>
        /// <example>JFK</example>
        public string Name { get; set; }

        /// <summary>
        /// The stations connected directly to the control tower.
        /// <seealso cref="StationControlTowerRelation"/>
        /// </summary>
        private ICollection<StationControlTowerRelation> firstStations;
        /// <summary>
        /// The stations connected directly to the control tower.
        /// <seealso cref="StationControlTowerRelation"/>
        /// </summary>
        public virtual ICollection<StationControlTowerRelation> FirstStations
        {
            get => lazyLoader.Load(this, ref firstStations);
            set => firstStations = value;
        }


        /// <summary>
        /// The flights waiting at the Control tower.
        /// <seealso cref="Flight"/>
        /// </summary>
        private ICollection<Flight> flightsWaiting;
        /// <summary>
        /// The flights waiting at the Control tower.
        /// <seealso cref="Flight"/>
        /// </summary>
        public virtual ICollection<Flight> FlightsWaiting
        {
            get => lazyLoader.Load(this, ref flightsWaiting);
            set => flightsWaiting = value;
        }
    }
}
