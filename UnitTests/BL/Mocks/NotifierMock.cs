using Common.Events;
using Common.Interfaces;
using Common.Models;
using System;

namespace UnitTests.BL.Mocks
{
    public class NotifierMock : INotifier
    {
        public FlightEventArgs FlightEventFromNotification { get; private set; }
        public void NotifyFlightChanges(FlightEventArgs flightEvent)
        {
            FlightEventFromNotification = flightEvent;
        }

        public void NotifyFutureFlightAdded(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
