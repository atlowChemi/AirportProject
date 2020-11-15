using Common.Enums;
using System;

namespace Common.Models
{
    public class StationRelation
    {
        public virtual Guid StationFromId { get; set; }
        public virtual Guid StationToId { get; set; }
        public FlightDirection Direction { get; set; }

        public virtual Station StationFrom { get; set; }
        public virtual Station StationTo { get; set; }
    }
}
