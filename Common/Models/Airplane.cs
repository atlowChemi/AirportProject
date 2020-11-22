using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// An airplane for the DB
    /// </summary>
    public class Airplane
    {
        /// <summary>
        /// ID of the airplane.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Name of airline which owns the airplane.
        /// </summary>
        public string AirLine { get; set; }
        /// <summary>
        /// All the <see cref="Flight">flights</see> this plane has been a part of.
        /// </summary>
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
