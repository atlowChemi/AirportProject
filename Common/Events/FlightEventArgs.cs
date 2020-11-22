using Common.Models;
using System;

namespace Common.Events
{
    public class FlightEventArgs : EventArgs
    {
        public Flight Flight{ get; init; }
        public Station StationFrom {get; init;}
        public Station StationTo {get; init;}

        public FlightEventArgs(Flight flight, Station stationFrom, Station stationTo)
        {
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            StationFrom = stationFrom ?? throw new ArgumentNullException(nameof(stationFrom));
            StationTo = stationTo;
        }
    }
}
