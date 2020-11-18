using Common.Enums;
using System;

namespace Common.Interfaces
{
    public interface IRelatedToStation
    {
        public Guid StationToId { get; set; }
        public FlightDirection Direction { get; set; }
    }
}
