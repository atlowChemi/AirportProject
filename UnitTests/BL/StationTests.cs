using BL.Services;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class StationTests
    {
        [Fact]
        public void StationServiceThrowsIfStationIsNull()
        {
            Assert.Throws<ArgumentNullException>("station", () => new StationService(null, 1));
        }

        [Fact]
        public void StationServiceThrowsIfWaitingToShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>("waitingTimeMS", () => new StationService(new Station(), 0));
        }

        [Fact]
        public void StationServiceHasExpectedWaitingTime()
        {
            IStationService station = new StationService(new Station(), 1000);
            Assert.Equal(1000, station.WaitingTimeMS);
        }

        [Fact]
        public void StationServiceRejectsFlightWhileBusy()
        {
            IStationService station = new StationService(new Station(), 1);

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };

            Assert.True(station.FlightArrived(flight1));
            Assert.Equal(station.CurrentFlight, flight1);
            Assert.False(station.IsHandlerAvailable);
            Assert.False(station.FlightArrived(flight2));
            Assert.Equal(station.CurrentFlight, flight1);
        }

        [Fact]
        public void StationServiceAcceptsFlightWhenAvailable()
        {
            IStationService station = new StationService(new Station(), 1);

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };

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
            IStationService station1 = new StationService(new Station(), 1);
            IStationService station2 = new StationService(new Station(), 1);
            station1.ConnectToNextStations(new IFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };

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
            IStationService station1 = new StationService(new Station(), 1);
            IStationService station2 = new StationService(new Station(), 1);
            station1.ConnectToNextStations(new IFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(station1.CurrentFlight, flight1);

            Assert.Null(station2.CurrentFlight);

            var evt = Assert.Raises<EventArgs>(xHandler => station1.AvailabiltyChange += xHandler, xHandler => station1.AvailabiltyChange -= xHandler, () => flight1.StopWaiting());

            Assert.NotNull(evt);
            Assert.Equal(station1, evt.Sender);
            Assert.Equal(EventArgs.Empty, evt.Arguments);

            Assert.True(station1.IsHandlerAvailable);
            Assert.Null(station1.CurrentFlight);
            Assert.Equal(station2.CurrentFlight, flight1);
        }

        [Fact]
        public void StationServiceTurnsAvailableIfNoContinuationStation()
        {
            IStationService station1 = new StationService(new Station(), 1);
            IStationService station2 = new StationService(new Station(), 1);
            station1.ConnectToNextStations(new IFlightHandler[] { station2 }, null);

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            FlightServiceMock flight2 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };

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
            IStationService stationStart = new StationService(new Station(), 1);
            IStationService stationLand = new StationService(new Station(), 1);
            IStationService stationTakoff = new StationService(new Station(), 1);
            stationStart.ConnectToNextStations(new IFlightHandler[] { stationLand }, new IFlightHandler[] { stationTakoff });

            FlightServiceMock flightLanding = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            FlightServiceMock flightTakoeff = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Takeoff } };

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
            IStationService stationStart = new StationService(new Station(), 1);
            IStationService stationLand = new StationService(new Station(), 1);
            IStationService stationTakoff = new StationService(new Station(), 1);
            stationStart.ConnectToNextStations(new IFlightHandler[] { stationLand }, new IFlightHandler[] { stationTakoff });

            FlightServiceMock flight1 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Takeoff } };
            FlightServiceMock flight2 = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Takeoff } };

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
            IHasNextStations station = new StationService(new Station(), 1);
            IFlightHandler[] landingStations = Array.Empty<IFlightHandler>();
            IFlightHandler[] takeoffStations = Array.Empty<IFlightHandler>();

            station.ConnectToNextStations(landingStations, takeoffStations);

            Assert.Equal(landingStations, station.LandingStations);
            Assert.Equal(takeoffStations, station.TakeoffStations);
        }
    }
}
