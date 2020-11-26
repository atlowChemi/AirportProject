using Common.Events;
using Common.Models;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    /// <summary>
    /// Service that can save changes to airport DB.
    /// </summary>
    public interface IAirportDBService
    {
        /// <summary>
        /// Update the database when a <see cref="Models.Flight">flight</see> has moved.
        /// </summary>
        /// <param name="flightEvent">The flight event arguments.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Flight"/> moving in DB</returns>
        Task FlightMoved(FlightEventArgs flightEvent);
    }
}
