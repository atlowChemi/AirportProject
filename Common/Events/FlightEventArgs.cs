using Common.Models;
using System;

namespace Common.Events
{
    /// <summary>
    /// Event arguments for flight movement between stations.
    /// </summary>
    public class FlightEventArgs : EventArgs
    {
        /// <summary>
        /// The flight which has moved.
        /// </summary>
        public Flight Flight{ get; init; }
        /// <summary>
        /// The station the flight has moved from.
        /// </summary>
        public Station StationFrom {get; init;}
        /// <summary>
        /// The station the flight has moved to.
        /// </summary>
        public Station StationTo {get; init;}
        /// <summary>
        /// Was the flight moved and placed in the initial starting station.
        /// </summary>
        public bool IsFromControlTowerToFirstStation => StationFrom is null && StationTo is not null;
        /// <summary>
        /// Was the flight moved from the last station into the black hole (GC).
        /// </summary>
        public bool IsFromLastStationToEnd => StationFrom is not null && StationTo is null;
        /// <summary>
        /// Is the flight self invoked by the owner station.
        /// </summary>
        public bool IsStationSelfInvoke => StationFrom == StationTo;

        /// <summary>
        /// Generate a new flight event arguments instance.
        /// </summary>
        /// <param name="flight">The flight which has moved.</param>
        /// <param name="stationFrom">The station the flight has moved from.</param>
        /// <param name="stationTo">The station the flight has moved to.</param>
        public FlightEventArgs(Flight flight, Station stationFrom, Station stationTo)
        {
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            if (stationFrom is null && stationTo is null) 
                throw new ArgumentNullException("stations", "Only one of the stations can be declared as null!");
            StationFrom = stationFrom;
            StationTo = stationTo;
        }
    }
}
