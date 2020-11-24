using Common.Enums;
using System;

namespace Common.DTO
{
    public class StationControlTowerRelationDTO
    {
        public FlightDirection Direction { get; init; }
        public Guid StationToId { get; init; }
        public Guid ControlTowerId { get; init; }
    }
}