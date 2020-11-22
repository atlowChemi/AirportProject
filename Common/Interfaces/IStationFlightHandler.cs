using Common.Events;
using Common.Models;
using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that can handle Incoming flights.
    /// </summary>
    public interface IStationFlightHandler : IGetFlights
    {
        /// <summary>
        /// The station the service is handeling.
        /// </summary>
        public Station Station { get; }
        /// <summary>
        /// Flight handler availability has changed.
        /// </summary>
        public event EventHandler<FlightEventArgs> AvailabiltyChange;
        /// <summary>
        /// Is handler is available currently.
        /// </summary>
        public bool IsHandlerAvailable { get; }
    }
}
