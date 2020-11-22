using Common.Enums;
using System;
using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// A flight from DB
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// The ID of the flight.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Name of <see cref="Models.ControlTower">control tower</see> flight is directed to.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Name of <see cref="Models.ControlTower">control tower</see> the flight departed from.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The planned takeoff/landing time at requested <see cref="Models.ControlTower">Control Tower</see>.
        /// </summary>
        public DateTime PlannedTime { get; set; }
        /// <summary>
        /// The <see cref="FlightDirection">direction</see> this flight is moving to in relation to the given <see cref="Models.ControlTower">Control Tower</see>
        /// </summary>
        public FlightDirection Direction { get; set; }
        /// <summary>
        /// Id of the <see cref="Models.Airplane">Airplane</see> taking this flight.
        /// </summary>
        public virtual int AirplaneId { get; set; }
        /// <summary>
        /// The <see cref="Models.Airplane">Airplane</see> taking this flight.
        /// </summary>
        public virtual Airplane Airplane { get; set; }
        /// <summary>
        /// Id of the <see cref="Models.ControlTower">Control Tower</see> this flight is waiting at.
        /// </summary>
        public virtual Guid? ControlTowerId { get; set; }
        /// <summary>
        /// The <see cref="Models.ControlTower">Control Tower</see> this flight is waiting at.
        /// </summary>
        public virtual ControlTower ControlTower { get; set; }

        /// <summary>
        /// The history of this flight regarding the stations.
        /// </summary>
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
