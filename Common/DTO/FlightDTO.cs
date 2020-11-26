using Common.Enums;
using Common.Models;
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
        public bool IsWaiting => !StationId.HasValue;

        public static FlightDTO FromDBModel(Flight flight)
        {
            return new()
            {
                Id = flight.Id,
                To = flight.To,
                From = flight.From,
                PlannedTime = flight.PlannedTime,
                Direction = flight.Direction,
                AirplaneId = flight.AirplaneId,
                ControlTowerId = flight.ControlTowerId,
                StationId = flight.StationId
            };
        }
    }
}