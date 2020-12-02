using Common.Models;

namespace Common.DTO
{
    /// <summary>
    /// A DTO for the <see cref="Airplane"/> class.
    /// </summary>
    public class AirplaneDTO
    {
        /// <summary>
        /// ID of the airplane.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Name of airline which owns the airplane.
        /// </summary>
        public string AirLine { get; init; }

        /// <summary>
        /// Genrate DTO object from a DB model.
        /// </summary>
        /// <param name="airplane">The <see cref="Airplane"/> to generate a DTO of.</param>
        /// <returns>A new AirplaneDTO instance.</returns>
        public static AirplaneDTO FromDBModel(Airplane airplane)
        {
            return new() { Id = airplane.Id, AirLine = airplane.AirLine };
        }
    }
}
