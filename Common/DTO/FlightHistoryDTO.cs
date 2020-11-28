using Common.Models;
using System;

namespace Common.DTO
{
    public class FlightHistoryDTO
    {

        public Guid Id { get; init; }
        public DateTime? EnterStationTime { get; init; }
        public DateTime? LeaveStationTime { get; init; }
        public FlightDTO Flight { get; init; }
        public StationDTO Station { get; init; }

        public static FlightHistoryDTO FromDBModel(FlightHistory flightHistory)
        {
            return new()
            {
                Id = flightHistory.Id,
                EnterStationTime = flightHistory.EnterStationTime,
                LeaveStationTime = flightHistory.LeaveStationTime,
                Flight = FlightDTO.FromDBModel(flightHistory.Flight),
                Station = StationDTO.FromDBModel(flightHistory.Station)
            };
        }
    }
}
