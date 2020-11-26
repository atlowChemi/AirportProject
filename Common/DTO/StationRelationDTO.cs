using Common.Enums;
using Common.Models;
using System;

namespace Common.DTO
{
    public class StationRelationDTO
    {

        public FlightDirection Direction { get; init; }
        public Guid StationFromId { get; init; }
        public Guid StationToId { get; init; }


        public static StationRelationDTO FromDBModel(StationRelation sr)
        {
            return new()
            {
                Direction = sr.Direction,
                StationFromId = sr.StationFromId,
                StationToId = sr.StationToId
            };
        }
    }
}