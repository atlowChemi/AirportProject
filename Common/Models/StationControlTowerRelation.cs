using Common.Enums;
using Common.Interfaces;
using System;

namespace Common.Models
{
    /// <summary>
    /// The relationship between a <see cref="Models.Station">station</see> and a <see cref="Models.ControlTower">control tower</see>.
    /// </summary>
    public class StationControlTowerRelation : IRelatedToStation
    {
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
        public virtual Station Station { get; set; }

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
