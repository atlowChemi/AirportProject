using Common.Interfaces;
using Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BL.Services
{
    /// <summary>
    /// Logical wrapper of a flight.
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IFlightService> logger;

        public Flight Flight { get; }

        public bool IsReadyToContinue { get; private set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        /// <summary>
        /// Generate a new instance of the flight service.
        /// </summary>
        /// <param name="flight">The flight this instance should handle.</param>
        /// <param name="logger">The logger for this service.</param>
        /// <exception cref="ArgumentNullException">The flight is null.</exception>
        public FlightService(Flight flight, ILogger<IFlightService> logger)
        {
            Flight = flight ??
                    throw new ArgumentNullException(nameof(flight), "A flight cannot be null! This is not Malaysia Airlines!");
            this.logger = logger;
        }

        public async Task StartWaitingInStationAsync(int delayInMS)
        {
            if (delayInMS < 0) throw new ArgumentOutOfRangeException(nameof(delayInMS), "Delay time cannot be negative!");
            logger.LogInformation($"Flight {Flight.Id} started waiting.");
            IsReadyToContinue = false;
            await Task.Delay(delayInMS);
            IsReadyToContinue = true;
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
            logger.LogInformation($"Flight {Flight.Id} finished waiting and is ready to move.");
        }
    }
}
