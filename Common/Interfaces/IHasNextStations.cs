using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IHasNextStations
    {
        IEnumerable<IRelatedToStation> NextStations { get; }
        IEnumerable<IFlightHandler> TakeoffStations { get; }
        IEnumerable<IFlightHandler> LandingStations { get; }
        public void ConnectToNextStations(IEnumerable<IFlightHandler> landingStations, IEnumerable<IFlightHandler> takeoffStations);
    }
}
