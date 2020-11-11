using BL.Models;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{   
    public class FlightTests
    {
        [Fact]
        public void FlightThrowsIfNegativeTime()
        {
            IFlight flight = new Flight();
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => flight.StartWaitingInStationAsync(-1));
            Assert.NotNull(ex);

        }

        [Fact]
        public void FlightNotifiesAfterAmountOfTime()
        {
            IFlight flight = new Flight();

            var evt = Assert.Raises<EventArgs>(
                xHandler => flight.ReadyToContinue += xHandler,
                xHandler => flight.ReadyToContinue -= xHandler,
                () => flight.StartWaitingInStationAsync(0));
        }
    }
}
