using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Mocks
{
    class FlightMock : IFlight
    {
        public Guid Id { get; set; }
        public FlightDirection Direction { get; set; }
        public IAirplane Airplane { get; set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        public void StartWaitingInStation(int delayInMS)
        {
            
        }
        public void StopWaiting()
        {
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
