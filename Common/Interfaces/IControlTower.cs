using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IControlTower : IFlightHandler
    {
        Queue<IAirplane> AirplanesWaitingToLand { get; }
        Queue<IAirplane> AirplanesWaitingToTakeoff { get; }
    }
}
