using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class FlightHistory
    {
        public Guid Id { get; set; }
        public DateTime? EnterStationTime { get; set; }
        public DateTime? LeaveStationTime { get; set; }
        public virtual Guid FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Guid StationId { get; set; }
        public virtual Station Station { get; set; }
    }
}
