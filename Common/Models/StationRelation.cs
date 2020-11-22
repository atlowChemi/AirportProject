using Common.Enums;
using Common.Interfaces;
using System;

namespace Common.Models
{
    /// <summary>
    /// The relationship between two <see cref="Station">stations</see>.
    /// </summary>
    public class StationRelation : IRelatedToStation
    {
        /// <summary>
        /// The ID of the <see cref="Station">Station</see> which is the parent of the relation.
        /// </summary>
        public virtual Guid StationFromId { get; set; }
        /// <summary>
        /// The ID of the <see cref="Station">Station</see> which is the child of the relation.
        /// </summary>
        public virtual Guid StationToId { get; set; }
        /// <summary>
        /// The <see cref="FlightDirection">direction</see> of the connection between the two <see cref="Station">Stations</see>.
        /// </summary>
        public FlightDirection Direction { get; set; }


        /// <summary>
        /// The <see cref="Station">Station</see> which is the parent of the relation.
        /// </summary>
        public virtual Station StationFrom { get; set; }
        /// <summary>
        /// The <see cref="Station">Station</see> which is the child of the relation.
        /// </summary>
        public virtual Station StationTo { get; set; }
    }
}
