using Common.Enums;
using Common.Models;
using System;

namespace Common.DTO
{
    public class StationControlTowerRelationDTO
    {
        public FlightDirection Direction { get; init; }
        public Guid StationToId { get; init; }
        public Guid ControlTowerId { get; init; }


        public static StationControlTowerRelationDTO FromDBModel(StationControlTowerRelation sctr)
        {
            return new()
            {
                Direction = sctr.Direction,
                StationToId = sctr.StationToId,
                ControlTowerId = sctr.ControlTowerId
            };
        }
    }
}