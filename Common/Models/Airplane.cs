using Common.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public string AirLine { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        [NotMapped]
        public IEnumerable<Flight> Takeoffs => Flights?.Where(f => f.Direction == FlightDirection.Takeoff);
        [NotMapped]
        public IEnumerable<Flight> Landings => Flights?.Where(f => f.Direction == FlightDirection.Landing);
    }
}
