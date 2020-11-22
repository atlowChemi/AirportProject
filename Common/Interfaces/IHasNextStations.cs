using System.Collections.Generic;

namespace Common.Interfaces
{
    /// <summary>
    /// An object which might be connected to continuation stations.
    /// </summary>
    public interface IHasNextStations
    {
        /// <summary>
        /// The relations to next stations, unsorted.
        /// </summary>
        IEnumerable<IRelatedToStation> NextStations { get; }
        /// <summary>
        /// A enumerable of the next flight handlers for takeoff.
        /// </summary>
        IEnumerable<IStationFlightHandler> TakeoffStations { get; }
        /// <summary>
        /// A enumerable of the next flight handlers for landing.
        /// </summary>
        IEnumerable<IStationFlightHandler> LandingStations { get; }
        /// <summary>
        /// Set the next station's flight handlers.
        /// </summary>
        /// <param name="landingStations">The handlers for the next landing stations</param>
        /// <param name="takeoffStations">The handlers for the next takeoff stations</param>
        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations);
    }
}
