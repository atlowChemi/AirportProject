using Common.Enums;
using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Element which has a relation to a station.
    /// </summary>
    public interface IRelatedToStation
    {
        /// <summary>
        /// The Guid of the station this element is related to.
        /// </summary>
        public Guid StationToId { get; set; }
        /// <summary>
        /// Direction of relation with station.
        /// </summary>
        public FlightDirection Direction { get; set; }
    }
}
