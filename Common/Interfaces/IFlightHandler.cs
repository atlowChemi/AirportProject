using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IFlightHandler
    {
        bool FlightArrived(IFlightService flight);

        public event EventHandler<EventArgs> AvailabiltyChange;

        public bool IsHandlerAvailable { get; }
    }
}
