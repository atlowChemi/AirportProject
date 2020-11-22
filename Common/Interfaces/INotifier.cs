using Common.Events;

namespace Common.Interfaces
{
    /// <summary>
    /// service that notifies When changes happen.
    /// </summary>
    public interface INotifier : IFutureFlightNotifier
    {
        /// <summary>
        /// Notify that a <see cref="Models.Flight">flight</see> has changed (moved between stations).
        /// </summary>
        /// <param name="flightEvent">The Flight event arguments.</param>
        void NotifyFlightChanges(FlightEventArgs flightEvent);
    }
}
