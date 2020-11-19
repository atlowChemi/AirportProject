using System.Collections.Generic;

namespace Common.Models
{
    public class Airplane
    {
        public int Id { get; init; }
        public string AirLine { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
