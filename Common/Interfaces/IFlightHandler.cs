using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IFlightHandler
    {
        ICollection<IStation> TakeoffStations { get; }
        ICollection<IStation> LandingStations { get; }
        bool FlightArrived(IFlight flight);
    }
}
