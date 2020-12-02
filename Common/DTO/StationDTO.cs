using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="Station"/> class.
    /// </summary>
    public class StationDTO
    {
        /// <summary>
        /// The Id of the station.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// The name of the station.
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// The Id of the <see cref="ControlTowerDTO">Control Tower</see> this station belongs to.
        /// </summary>
        public Guid ControlTowerId { get; init; }
        /// <summary>
        /// The currnet <see cref="FlightDTO">Flight</see> in the DB.
        /// </summary>
        public FlightDTO CurrentFlight { get; init; }



        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> to generate a DTO of.</param>
        /// <returns>A new StationDTO instance.</returns>
        public static StationDTO FromDBModel(Station station)
        {
            return new()
            {
                Id = station.Id,
                Name = station.Name,
                ControlTowerId = station.ControlTowerId,
                CurrentFlight = station.CurrentFlight != null ? FlightDTO.FromDBModel(station.CurrentFlight) : null
            };
        }
    }
}