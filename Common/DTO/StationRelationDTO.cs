using Common.Enums;
using System;

namespace Common.DTO
{
    public class StationRelationDTO
    {

        public FlightDirection Direction { get; init; }
        public Guid StationFromId { get; init; }
        public Guid StationToId { get; init; }
    }
}