using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    class FlightMock : IFlight
    {
        public Guid Id { get; set; }
        public FlightDirection Direction { get; set; }
        public IAirplane Airplane { get; set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        public Task StartWaitingInStationAsync(int delayInMS)
        {
            return Task.Run(() => { });
        }
        public void StopWaiting()
        {
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
