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
        public virtual ICollection<StationControlTowerRelation> FirstStations { get; set; }
        /// <summary>
        /// The flights waiting at the Control tower.
        /// <seealso cref="Flight"/>
        /// </summary>
        public virtual ICollection<Flight> FlightsWaiting { get; set; }
        /// <summary>
        /// The <see cref="Station">Stations</see> of the Control tower.
        /// </summary>
        public virtual ICollection<Station> Stations { get; set; }
    }
}
