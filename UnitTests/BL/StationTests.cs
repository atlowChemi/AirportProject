using BL.Services;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using System;
using UnitTests.Mocks;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class StationTests
    {
        private readonly LoggerFactoryMock loggerFactoryMock = new();

        [Fact]
        public void StationServiceThrowsIfWaitingToShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>("waitingTimeMS", () => new StationService(new Station(), 0, null));
        }

        [Fact]
        public void StationServiceThrowsIfStationIsNull()
        {
            Assert.Throws<ArgumentNullException>("station", () => new StationService(null, 1, null));
        }

        [Fact]
        public void StationServiceThrowsIfLoggerFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>("loggerFactory", () => new StationService(new(), 1, null));
        }

        [Fact]
        public void StationServiceHasExpectedWaitingTime()
        {
            IStationService station = new StationService(new(), 1000, loggerFactoryMock);
            Assert.Equal(1000, station.WaitingTimeMS);
        }

        [Fact]
        public void StationServiceRejectsFlightWhileBusy()
        {
            IStationService station = new StationService(new(), 1, loggerFactoryMock);

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Landing } };

            Assert.True(station.FlightArrived(flight1));
            Assert.Equal(station.CurrentFlight, flight1);
            Assert.False(station.IsHandlerAvailable);
            Assert.False(station.FlightArrived(flight2));
            Assert.Equal(station.CurrentFlight, flight1);
        }

        [Fact]
        public void StationServiceAcceptsFlightWhenAvailable()
        {
            IStationService station = new StationService(new(), 1, loggerFactoryMock);

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Landing } };

            Assert.True(station.FlightArrived(flight1));
            Assert.False(station.IsHandlerAvailable);
            Assert.Equal(station.CurrentFlight, flight1);

            flight1.StopWaiting();
            Assert.Null(station.CurrentFlight);
            Assert.True(station.IsHandlerAvailable);
            Assert.True(station.FlightArrived(flight2));
            Assert.Equal(station.CurrentFlight, flight2);
        }

        [Fact]
        public void PlaneWaitInStationIfNextStationIsNotAvailable()
        {
            IStationService station1 = new StationService(new(), 1, loggerFactoryMock);
            IStationService station2 = new StationService(new(), 1, loggerFactoryMock);
            station1.ConnectToNextStations(new IStationFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Landing } };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(station1.CurrentFlight, flight1);

            Assert.True(station2.FlightArrived(flight2));
            Assert.Equal(station2.CurrentFlight, flight2);

            flight1.StopWaiting();

            Assert.False(station1.IsHandlerAvailable);
            Assert.Equal(station1.CurrentFlight, flight1);
            Assert.NotEqual(station2.CurrentFlight, flight1);
            Assert.Equal(station2.CurrentFlight, flight2);
        }

        [Fact]
        public void StationServiceMarksAsAvailableWhenPlaneDeparts()
        {
            IStationService station1 = new StationService(new(), 1, loggerFactoryMock);
            IStationService station2 = new StationService(new(), 1, loggerFactoryMock);
            station1.ConnectToNextStations(new IStationFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Landing } };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(station1.CurrentFlight, flight1);

            Assert.Null(station2.CurrentFlight);

            var evt = Assert.Raises<FlightEventArgs>(xHandler => station1.FlightChanged += xHandler, xHandler => station1.FlightChanged -= xHandler, () => flight1.StopWaiting());

            Assert.NotNull(evt);
            Assert.Equal(station1, evt.Sender);
            Assert.Equal(flight1.Flight, evt.Arguments.Flight);
            Assert.Equal(station1.Station, evt.Arguments.StationFrom);
            Assert.Equal(station2.Station, evt.Arguments.StationTo);

            Assert.True(station1.IsHandlerAvailable);
            Assert.Null(station1.CurrentFlight);
            Assert.Equal(station2.CurrentFlight, flight1);
        }

        [Fact]
        public void StationServiceTurnsAvailableIfNoContinuationStation()
        {
            IStationService station1 = new StationService(new(), 1, loggerFactoryMock);
            IStationService station2 = new StationService(new(), 1, loggerFactoryMock);
            station1.ConnectToNextStations(new IStationFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Landing } };

            Assert.True(station2.FlightArrived(flight1));
            Assert.True(station1.FlightArrived(flight2));

            Assert.False(station2.IsHandlerAvailable);
            Assert.Equal(station2.CurrentFlight, flight1);

            Assert.False(station1.IsHandlerAvailable);
            Assert.Equal(station1.CurrentFlight, flight2);

            flight2.StopWaiting();
            Assert.False(station1.IsHandlerAvailable);
            Assert.Equal(station1.CurrentFlight, flight2);

            flight1.StopWaiting();
            Assert.True(station1.IsHandlerAvailable);
            Assert.False(station2.IsHandlerAvailable);
            Assert.Equal(station2.CurrentFlight, flight2);
        }

        [Fact]
        public void StationServiceSendsPlainToCorrectNextStation()
        {
            IStationService stationStart = new StationService(new(), 1, loggerFactoryMock);
            IStationService stationLand = new StationService(new(), 1, loggerFactoryMock);
            IStationService stationTakoff = new StationService(new(), 1, loggerFactoryMock);
            stationStart.ConnectToNextStations(new IStationFlightHandler[] { stationLand }, new IStationFlightHandler[] { stationTakoff });

            FlightServiceMock flightLanding = new() { Flight = new() { Direction = FlightDirection.Landing } };
            FlightServiceMock flightTakoeff = new() { Flight = new() { Direction = FlightDirection.Takeoff } };

            Assert.True(stationStart.FlightArrived(flightLanding));
            Assert.False(stationStart.IsHandlerAvailable);
            Assert.Equal(stationStart.CurrentFlight, flightLanding);

            Assert.True(stationLand.IsHandlerAvailable);
            Assert.True(stationTakoff.IsHandlerAvailable);

            flightLanding.StopWaiting();

            Assert.True(stationStart.IsHandlerAvailable);
            Assert.False(stationLand.IsHandlerAvailable);
            Assert.Equal(stationLand.CurrentFlight, flightLanding);

            Assert.True(stationStart.FlightArrived(flightTakoeff));

            Assert.False(stationStart.IsHandlerAvailable);
            Assert.Equal(stationStart.CurrentFlight, flightTakoeff);

            flightTakoeff.StopWaiting();

            Assert.True(stationStart.IsHandlerAvailable);
            Assert.False(stationTakoff.IsHandlerAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flightTakoeff);
        }

        [Fact]
        public void StationServiceDowsNotSendPlainToIncorrectNextStation()
        {
            IStationService stationStart = new StationService(new(), 1, loggerFactoryMock);
            IStationService stationLand = new StationService(new(), 1, loggerFactoryMock);
            IStationService stationTakoff = new StationService(new(), 1, loggerFactoryMock);
            stationStart.ConnectToNextStations(new IStationFlightHandler[] { stationLand }, new IStationFlightHandler[] { stationTakoff });

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Takeoff } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Takeoff } };

            Assert.True(stationStart.FlightArrived(flight1));
            Assert.False(stationStart.IsHandlerAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight1);

            Assert.True(stationLand.IsHandlerAvailable);
            Assert.True(stationTakoff.IsHandlerAvailable);

            flight1.StopWaiting();

            Assert.True(stationStart.IsHandlerAvailable);
            Assert.False(stationTakoff.IsHandlerAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flight1);

            Assert.True(stationStart.FlightArrived(flight2));
            Assert.False(stationStart.IsHandlerAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight2);

            flight2.StopWaiting();

            Assert.False(stationStart.IsHandlerAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight2);
            Assert.False(stationTakoff.IsHandlerAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flight1);
            Assert.True(stationLand.IsHandlerAvailable);
            Assert.Null(stationLand.CurrentFlight);
        }

        [Fact]
        public void StationServiceShouldSaveNextStations()
        {
            IHasNextStations station = new StationService(new Station(), 1, loggerFactoryMock);
            IStationFlightHandler[] landingStations = Array.Empty<IStationFlightHandler>();
            IStationFlightHandler[] takeoffStations = Array.Empty<IStationFlightHandler>();

            station.ConnectToNextStations(landingStations, takeoffStations);

            Assert.Equal(landingStations, station.LandingStations);
            Assert.Equal(takeoffStations, station.TakeoffStations);
        }
    }
}
