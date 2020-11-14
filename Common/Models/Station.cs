using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CurrentFlightId { get; set; }
        public Flight CurrentFlight { get; set; }
        public virtual ICollection<Station> TakeoffStations { get; set; }
        public virtual ICollection<Station> LandingStations { get; set; }
    }
}
