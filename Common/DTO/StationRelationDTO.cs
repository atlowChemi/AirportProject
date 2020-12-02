using Common.Enums;
using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="StationRelation"/> class.
    /// </summary>
    public class StationRelationDTO
    {
        /// <summary>
        /// The <see cref="FlightDirection">direction</see> of the connection between the two <see cref="Station">Stations</see>.
        /// </summary>
        public FlightDirection Direction { get; init; }
        /// <summary>
        /// The ID of the <see cref="Station">Station</see> which is the parent of the relation.
        /// </summary>
        public Guid StationFromId { get; init; }
        /// <summary>
        /// The ID of the <see cref="Station">Station</see> which is the child of the relation.
        /// </summary>
        public Guid StationToId { get; init; }



        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="sr">The <see cref="StationRelation"/> to generate a DTO of.</param>
        /// <returns>A new StationRelationDTO instance.</returns>
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