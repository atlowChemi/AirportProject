using Common.Interfaces;
using Common.Models;
using System;
using System.Threading.Tasks;

namespace UnitTests.BL.Mocks
{
    class FlightServiceMock : IFlightService
    {
        public Flight Flight { get; set; }

        public bool IsReadyToContinue { get; set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        public Task StartWaitingInStationAsync(int delayInMS)
        {
            IsReadyToContinue = false;
            return null;
        }

        public void StopWaiting()
        {
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
            IsReadyToContinue = true;
        }
    }
}
