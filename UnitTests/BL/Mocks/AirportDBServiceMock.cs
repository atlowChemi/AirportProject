using Common.Events;
using Common.Interfaces;
using System.Threading.Tasks;

namespace UnitTests.BL.Mocks
{
    class AirportDBServiceMock : IAirportDBService
    {
        public FlightEventArgs FlightEventFromNotification { get; private set; }
        public Task FlightMoved(FlightEventArgs flightEvent)
        {
            FlightEventFromNotification = flightEvent;
            return null;
        }
    }
}
