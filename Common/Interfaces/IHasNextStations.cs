using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IHasNextStations
    {
        IEnumerable<IRelatedToStation> NextStations { get; }
        IEnumerable<IStationService> TakeoffStations { get; }
        IEnumerable<IStationService> LandingStations { get; }
        public void ConnectToNextStations(IEnumerable<IStationService> landingStations, IEnumerable<IStationService> takeoffStations);
    }
}
