using BL.Services;
using Common.Interfaces;
using System;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class FlightTests
    {
        private readonly LoggerMock<IFlightService> loggerMock = new();

        [Fact]
        public void FlightServiceThrowsIfFlightIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>("flight", () => new FlightService(null, null));
            Assert.NotNull(ex);
        }

        [Fact]
        public void FlightServiceThrowsIfLoggerIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>("logger", () => new FlightService(new(), null));
            Assert.NotNull(ex);
        }

        [Fact]
        public void FlightServiceThrowsIfNegativeTime()
        {
            IFlightService flight = new FlightService(new(), loggerMock);
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => flight.StartWaitingInStationAsync(-1));
            Assert.NotNull(ex);

        }

        [Fact]
        public void FlightServiceNotifiesAfterAmountOfTime()
        {
            IFlightService flight = new FlightService(new(), loggerMock);

            var evt = Assert.RaisesAsync<EventArgs>(
                xHandler => flight.ReadyToContinue += xHandler,
                xHandler => flight.ReadyToContinue -= xHandler,
                () => flight.StartWaitingInStationAsync(0));
        }

        [Fact]
        public void FlightServiceIsFlaggedAsReadyOnlyWhenReady()
        {

            IFlightService flight = new FlightService(new(), loggerMock);
            Assert.False(flight.IsReadyToContinue);
            flight.StartWaitingInStationAsync(0);
            Assert.True(flight.IsReadyToContinue);
        }
    }
}
