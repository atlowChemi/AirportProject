using Common.Models;
using System;

namespace Common.Events
{
    public class FlightEventArgs : EventArgs
    {
        public Flight Flight{ get; init; }
        public Station StationFrom {get; init;}
        public Station StationTo {get; init;}
        public bool IsFromControlTowerToFirstStation => StationFrom is null && StationTo is not null;
        public bool IsFromLastStationToEnd => StationFrom is not null && StationTo is null;
        public bool IsStationSelfInvoke => StationFrom == StationTo;

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
