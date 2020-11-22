using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that can handle Incoming flights.
    /// </summary>
    public interface IFlightHandler : IGetFlights
    {
        /// <summary>
        /// Flight handler availability has changed.
        /// </summary>
        public event EventHandler<EventArgs> AvailabiltyChange;
        /// <summary>
        /// Is handler is available currently.
        /// </summary>
        public bool IsHandlerAvailable { get; }
    }
}
