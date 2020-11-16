using Common.Enums;
using System;

namespace Common.Models
{
    public class StationControlTowerRelation
    {
        public FlightDirection Direction { get; set; }

        public virtual Guid StationId { get; set; }
        public virtual Station Station { get; set; }
        public virtual Guid ControlTowerId { get; set; }
        public virtual ControlTower ControlTower { get; set; }
    }
}
