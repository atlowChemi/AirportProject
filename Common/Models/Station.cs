using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Guid? CurrentFlightId { get; set; }
        public virtual Flight CurrentFlight { get; set; }
        public virtual StationControlTowerRelation ControlTowerRelation { get; set; }

        public virtual ICollection<StationRelation> ParentStations { get; set; }
        public virtual ICollection<StationRelation> ChildrenStations { get; set; }
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
