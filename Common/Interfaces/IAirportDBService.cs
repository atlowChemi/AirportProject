using Common.Events;
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
        /// <returns>An awaitable task.</returns>
        Task FlightMoved(FlightEventArgs flightEvent);
    }
}
