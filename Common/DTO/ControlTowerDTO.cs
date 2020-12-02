using Common.Models;
using System;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="ControlTower"/> class.
    /// </summary>
    public class ControlTowerDTO
    {
        /// <summary>
        /// ID of the Control Tower.
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Name of the Control Tower.
        /// </summary>
        /// <example>TLV</example>
        /// <example>JFK</example>
        public string Name { get; init; }


        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="controlTower">The <see cref="ControlTower"/> to generate a DTO of.</param>
        /// <returns>A new ControlTowerDTO instance.</returns>
        public static ControlTowerDTO FromDBModel(ControlTower controlTower)
        {
            return new(){ Id = controlTower.Id, Name = controlTower.Name };
        }
    }
}