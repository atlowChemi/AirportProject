using Common.Models;
using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Can notifiy regarding new future flights added.
    /// </summary>
    public interface IFutureFlightNotifier
    {
        /// <summary>
        /// Notify there was a new flight added which is a future flight.
        /// </summary>
        /// <param name="flight">The added flight.</param>
        /// <exception cref="ArgumentNullException">Flight is null.</exception>
        void NotifyFutureFlightAdded(Flight flight);
    }
}