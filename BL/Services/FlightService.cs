using Common.Interfaces;
using Common.Models;
using System;
using System.Threading.Tasks;

namespace BL.Services
{
    /// <summary>
    /// Logical wrapper of a flight.
    /// </summary>
    public class FlightService : IFlightService
    {
        public Flight Flight { get; }

        public bool IsReadyToContinue { get; private set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        /// <summary>
        /// Generate a new instance of the flight service.
        /// </summary>
        /// <param name="flight">The flight this instance should handle.</param>
        /// <exception cref="ArgumentNullException">The flight is null.</exception>
        public FlightService(Flight flight)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot be null! This is not Malaysia Airlines!");
            Flight = flight;
        }

        public async Task StartWaitingInStationAsync(int delayInMS)
        {
            if (delayInMS < 0) throw new ArgumentOutOfRangeException(nameof(delayInMS), "Delay time cannot be negative!");
            IsReadyToContinue = false;
            await Task.Delay(delayInMS);
            IsReadyToContinue = true;
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
