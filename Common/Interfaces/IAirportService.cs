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
        /// Get all <see cref="Airplane">airplanes</see> available.
        /// </summary>
        /// <returns>All airplanes in the system.</returns>
        IEnumerable<Airplane> GetAirplanes();
        /// <summary>
        /// Handle the situation of a new <see cref="Flight"/> arriving the airport.
        /// </summary>
        /// <param name="flight">The flight that has arrived.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Flight"/> handeling</returns>
        Task HandleNewFlightArrivedAsync(Flight flight);
        /// <summary>
        /// Get all <see cref="Flight">Flights</see> which did not yet start the land/takeoff procedure.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Flight}"/> with waiting flights.</returns>
        IEnumerable<Flight> GetWaitingFlights();
        /// <summary>
        /// Get the <see cref="ControlTower"/> with the a given name.
        /// </summary>
        /// <param name="name">The name of the control tower</param>
        /// <returns>The control tower requested.</returns>
        ControlTower GetControlTower(string name);
    }
}
