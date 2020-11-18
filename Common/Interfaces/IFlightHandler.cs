using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IFlightHandler
    {
        bool FlightArrived(IFlight flight);
    }
}
