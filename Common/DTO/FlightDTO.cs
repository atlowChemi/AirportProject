using Common.Enums;
using System;

namespace Common.DTO
{
    public class FlightDTO
    {
        public Guid Id { get; init; }
        public string To { get; init; }
        public string From { get; init; }
        public DateTime PlannedTime { get; init; }
        public FlightDirection Direction { get; init; }
        public int AirplaneId { get; init; }
        public Guid? ControlTowerId { get; init; }
        public Guid? StationId { get; init; }
    }
}