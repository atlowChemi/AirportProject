using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    /// <summary>
    /// Service to handle the whole orchestra of the airport.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Get all airplanes available.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airplane> GetAirplanes();
        /// <summary>
        /// Handle the situation of a new flight arriving the airport.
        /// </summary>
        /// <param name="flight">The flight that has arrived.</param>
        /// <returns>The flight after inserted to DB.</returns>
        Task<Flight> HandleNewFlightArrivedAsync(Flight flight);
    }
}
