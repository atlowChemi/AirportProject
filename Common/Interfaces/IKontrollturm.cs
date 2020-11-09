using System.Collections.Generic;

namespace Common.Interfaces
{
    interface IKontrollturm : IAirplaneHandler
    {
        List<IAirplane> AirplanesInAir { get; }
        Queue<IAirplane> AirplanesWaitingToLand { get; }
        Queue<IAirplane> AirplanesWaitingToTakeoff { get; }
    }
}
