using Microsoft.EntityFrameworkCore.Infrastructure;
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
        /// The lazy loading handler.
        /// </summary>
        private readonly ILazyLoader lazyLoader;

        /// <summary>
        /// Create a new instance of a Station.
        /// </summary>
        public Station() { }
        /// <summary>
        /// Create a new instance of a Station.
        /// </summary>
        /// <param name="lazyLoader">Lazy loader to use through out the model.</param>
        public Station(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

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
        private Flight currentFlight;
        /// <summary>
        /// The currnet <see cref="Flight">Flight</see> in the DB.
        /// </summary>
        public virtual Flight CurrentFlight
        {
            get => lazyLoader.Load(this, ref currentFlight);
            set => currentFlight = value;
        }
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
        private StationControlTowerRelation controlTowerRelation;
        /// <summary>
        /// The relation with a control tower.
        /// </summary>
        public virtual StationControlTowerRelation ControlTowerRelation
        {
            get => lazyLoader.Load(this, ref controlTowerRelation);
            set => controlTowerRelation = value;
        }

        /// <summary>
        /// The stations which are parents for this station.
        /// </summary>
        private ICollection<StationRelation> parentStations;
        /// <summary>
        /// The stations which are parents for this station.
        /// </summary>
        public virtual ICollection<StationRelation> ParentStations
        {
            get => lazyLoader.Load(this, ref parentStations);
            set => parentStations = value;
        }
        /// <summary>
        /// The stations which are children for this station.
        /// </summary>
        private ICollection<StationRelation> childrenStations;

        /// <summary>
        /// The stations which are children for this station.
        /// </summary>
        public virtual ICollection<StationRelation> ChildrenStations
        {
            get => lazyLoader.Load(this, ref childrenStations);
            set => childrenStations = value;
        }
        /// <summary>
        /// The <see cref="FlightHistory">History</see> of <see cref="Flight">Flights</see> which have been throught this station.
        /// </summary>
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
