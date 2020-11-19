using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IStationService : IFlightHandler, IHasNextStations
    {
        public Station Station { get; }
        public IFlightService CurrentFlight { get; }
        public int WaitingTimeMS { get; }
    }
}