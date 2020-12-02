using System;

namespace Common.Models
{
    /// <summary>
    /// The history of the <see cref="Models.Flight">Flight</see> and the <see cref="Models.Station">Station</see>
    /// </summary>
    public class FlightHistory
    {
        /// <summary>
        /// The ID of this History record.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// The time the <see cref="Models.Flight">flight</see> entered the <see cref="Models.Station">station</see>.
        /// </summary>
        public DateTime? EnterStationTime { get; set; }
        /// <summary>
        /// The time the <see cref="Models.Flight">flight</see> left the <see cref="Models.Station">station</see>.
        /// </summary>
        public DateTime? LeaveStationTime { get; set; }
        /// <summary>
        /// The ID of the <see cref="Models.Flight">Flight</see> this is the history of.
        /// </summary>
        public virtual Guid FlightId { get; set; }
        /// <summary>
        /// The <see cref="Models.Flight">Flight</see> this is the history of.
        /// </summary>
        public virtual Flight Flight { get; set; }
        /// <summary>
        /// The ID of the <see cref="Models.Station">Station</see> this is the history of.
        /// </summary>
        public virtual Guid StationId { get; set; }
        /// <summary>
        /// The <see cref="Models.Station">Station</see> this is the history of.
        /// </summary>
        public virtual Station Station { get; set; }
    }
}
