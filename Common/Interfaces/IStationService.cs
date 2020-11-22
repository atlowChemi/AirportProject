namespace Common.Interfaces
{
    /// <summary>
    /// Logical wrapper for Stations.
    /// </summary>
    public interface IStationService : IStationFlightHandler, IHasNextStations
    {
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