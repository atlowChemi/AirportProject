using Common.Enums;
using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="StationControlTowerRelation"/> class.
    /// </summary>
    public class StationControlTowerRelationDTO
    {
        /// <summary>
        /// The <see cref="FlightDirection">direction</see> the flights can arrive to this station.
        /// </summary>
        public FlightDirection Direction { get; init; }
        /// <summary>
        /// The ID of the <see cref="Models.Station">Station</see> which is related to the <see cref="Models.ControlTower">control tower</see>.
        /// </summary>
        public Guid StationToId { get; init; }
        /// <summary>
        /// The ID of the <see cref="Models.ControlTower">control tower</see> related to the <see cref="Station">Station</see>
        /// </summary>
        public Guid ControlTowerId { get; init; }


        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="sctr">The <see cref="StationControlTowerRelation"/> to generate a DTO of.</param>
        /// <returns>A new StationControlTowerRelationDTO instance.</returns>
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