using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that is capable of getting a flight.
    /// </summary>
    public interface IGetFlights
    {
        /// <summary>
        /// Accept an incoming flight.
        /// </summary>
        /// <param name="flight">Flight to accept.</param>
        /// <returns>True if flight was accepted, false if flight was declined.</returns>
        /// <exception cref="ArgumentNullException">The flght service sent was null.</exception>
        bool FlightArrived(IFlightService flight);
    }
}
