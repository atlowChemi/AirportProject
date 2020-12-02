using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="FlightHistory"/> class.
    /// </summary>
    public class FlightHistoryDTO
    {
        /// <summary>
        /// The ID of this History record.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// The time the <see cref="Models.Flight">flight</see> entered the <see cref="Models.Station">station</see>.
        /// </summary>
        public DateTime? EnterStationTime { get; init; }
        /// <summary>
        /// The time the <see cref="Models.Flight">flight</see> left the <see cref="Models.Station">station</see>.
        /// </summary>
        public DateTime? LeaveStationTime { get; init; }
        /// <summary>
        /// The <see cref="FlightDTO">Flight</see> this is the history of.
        /// </summary>
        public FlightDTO Flight { get; init; }
        /// <summary>
        /// The <see cref="StationDTO">Station</see> this is the history of.
        /// </summary>
        public StationDTO Station { get; init; }


        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="flightHistory">The <see cref="FlightHistory"/> to generate a DTO of.</param>
        /// <returns>A new FlightHistoryDTO instance.</returns>
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
