using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that can handle Incoming flights.
    /// </summary>
    public interface IFlightHandler
    {
        /// <summary>
        /// Accept an incoming flight.
        /// </summary>
        /// <param name="flight">Flight to accept.</param>
        /// <returns>True if flight was accepted, false if flight was declined.</returns>
        bool FlightArrived(IFlightService flight);
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
