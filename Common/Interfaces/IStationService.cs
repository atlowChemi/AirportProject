using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    /// <summary>
    /// Logical wrapper for Stations.
    /// </summary>
    public interface IStationService : IFlightHandler, IHasNextStations
    {
        /// <summary>
        /// The station the service is handeling.
        /// </summary>
        public Station Station { get; }
        /// <summary>
        /// The logical flight currently in station.
        /// </summary>
        public IFlightService CurrentFlight { get; }
        /// <summary>
        /// The waiting time required for this station.
        /// </summary>
        public int WaitingTimeMS { get; }
    }
}