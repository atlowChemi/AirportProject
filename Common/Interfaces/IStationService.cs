using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IStationService : IFlightHandler, IHasNextStations
    {
        public Station Station { get; }
        public IFlight CurrentFlight { get; }
        public bool IsStationAvailable { get; }
        public int WaitingTimeMS { get; }
        public event EventHandler<EventArgs> AvailabiltyChange;
    }
}