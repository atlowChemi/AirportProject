using Common.Models;
using System;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    /// <summary>
    /// Logical wrapper for Flights.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// The flight the service is handeling.
        /// </summary>
        public Flight Flight { get; }
        /// <summary>
        /// Flag marking if the flight is done waiting in a station.
        /// </summary>
        public bool IsReadyToContinue { get; }
        /// <summary>
        /// Raised when flight is done waiting in a station.
        /// </summary>
        public event EventHandler<EventArgs> ReadyToContinue;
        /// <summary>
        /// Start waiting with the flight in given station.
        /// </summary>
        /// <param name="delayInMS">Amount of delay in MS of the given station.</param>
        /// <returns>An awaitable task untill waiting has complete.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The delay is negative.</exception>
        Task StartWaitingInStationAsync(int delayInMS);
    }
}
