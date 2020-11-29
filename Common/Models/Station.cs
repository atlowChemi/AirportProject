using System;
using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// A station from DB
    /// </summary>
    public class Station
    {
        /// <summary>
        /// The Id of the station.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// The name of the station.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Id of the currnet <see cref="Flight">Flight</see> in the DB.
        /// </summary>
        public virtual Guid? CurrentFlightId { get; set; }
        /// <summary>
        /// The currnet <see cref="Flight">Flight</see> in the DB.
        /// </summary>
        public virtual Flight CurrentFlight { get; set; }
        /// <summary>
        /// The Id of the <see cref="Models.ControlTower">Control Tower</see> this station belongs to.
        /// </summary>
        public virtual Guid ControlTowerId { get; set; }
        /// <summary>
        /// The <see cref="Models.ControlTower">Control Tower</see> this station belongs to.
        /// </summary>
        public virtual ControlTower ControlTower { get; set; }

        /// <summary>
        /// The relation with a control tower.
        /// </summary>
        public virtual StationControlTowerRelation ControlTowerRelation { get; set; }

        /// <summary>
        /// The stations which are parents for this station.
        /// </summary>
        public virtual ICollection<StationRelation> ParentStations { get; set; }

        /// <summary>
        /// The stations which are children for this station.
        /// </summary>
        public virtual ICollection<StationRelation> ChildrenStations { get; set; }
        /// <summary>
        /// The <see cref="FlightHistory">History</see> of <see cref="Flight">Flights</see> which have been throught this station.
        /// </summary>
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
