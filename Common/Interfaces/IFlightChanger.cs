using Common.Events;
using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that can modify flights.
    /// </summary>
    public interface IFlightChanger
    {

        /// <summary>
        /// Flight was changed.
        /// </summary>
        public event EventHandler<FlightEventArgs> FlightChanged;
    }
}
