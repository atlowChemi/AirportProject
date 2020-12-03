using BL.Services;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class AirportEventsTests
    {
        [Fact]
        public void AirportEventServiceShouldThrowIfNotifierIsNull()
        {
            Assert.Throws<ArgumentNullException>("notifier", () => new AirportEventsService(null, null, null));
        }

        [Fact]
        public void AirportEventServiceShouldThrowIfDBServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>("airportDBService", () => new AirportEventsService(new NotifierMock(), null, null));
        }

        [Fact]
        public void AirportEventServiceShouldThrowIfLoggerIsNull()
        {
            Assert.Throws<ArgumentNullException>("airportDBService", () => new AirportEventsService(new NotifierMock(), new AirportDBServiceMock(), null));
        }

        [Fact]
        public void AirportEventServiceShouldThrowIfStationServicesAreNull()
        {
            AirportEventsService airportEventsService = new(new NotifierMock(), new AirportDBServiceMock(), new LoggerMock<IAirportEventsService>());

            Assert.Throws<ArgumentNullException>("stationServices", () => airportEventsService.AddStationsToListenTo(null));
        }

        [Fact]
        public void AirportEventServiceShouldNotifySameEventInBothPlaces()
        {
            NotifierMock notifier = new();
            AirportDBServiceMock airportDBServiceMock = new();
            LoggerMock<IAirportEventsService> logger = new();
            AirportEventsService airportEventsService = new(notifier, airportDBServiceMock, logger);

            StationServiceMock stationServiceMock = new();
            IFlightChanger[] flightChangers = { stationServiceMock };

            Assert.Null(notifier.FlightEventFromNotification);

            airportEventsService.AddStationsToListenTo(flightChangers);

            stationServiceMock.RaiseFlightChanged();

            Assert.NotNull(notifier.FlightEventFromNotification);
            Assert.NotNull(airportDBServiceMock.FlightEventFromNotification);

            Assert.Equal(notifier.FlightEventFromNotification, airportDBServiceMock.FlightEventFromNotification);
        }
    }
}
