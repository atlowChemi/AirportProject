using BL.Services;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class ControlTowerTests
    {
        private readonly LoggerFactoryMock loggerFactory = new();

        [Fact]
        public void ControlTowerServiceShouldThrowIfControlTowerIsNull()
        {
            Assert.Throws<ArgumentNullException>("controlTower", () => new ControlTowerService(null, null));
        }
        
        [Fact]
        public void ControlTowerServiceShouldThrowIfLoggerFactoryIsNull()
        {
            ControlTower controlTower = new();
            Assert.Throws<ArgumentNullException>("loggerFactory", () => new ControlTowerService(controlTower, null));
        }

        [Fact]
        public void ControlTowerServiceShouldHaveExpectedControlTower()
        {
            ControlTower controlTower = new();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower, loggerFactory);

            Assert.Equal(controlTower, controlTowerService.ControlTower);
        }

        [Fact]
        public void ControlTowerServiceShouldHaveExpectedNextStations()
        {
            IStationFlightHandler[] flightHandlerLanding = new IStationFlightHandler[] { new StationService(new(), 1, loggerFactory) };
            IStationFlightHandler[] flightHandlerTakeoff = new IStationFlightHandler[] { new StationService(new(), 1, loggerFactory) };
            IControlTowerService controlTowerService = new ControlTowerService(new(), loggerFactory);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, flightHandlerTakeoff);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);
            Assert.Equal(flightHandlerTakeoff, controlTowerService.TakeoffStations);
        }

        [Fact]
        public void ControlTowerServiceThrowsIfNullFlight()
        {
            IControlTowerService controlTowerService = new ControlTowerService(new(), loggerFactory);
            Assert.Throws<ArgumentNullException>("flightService", () => controlTowerService.FlightArrived(null));
        }

        [Fact]
        public void ControlTowerServiceSendsFlightToStation()
        {
            IStationFlightHandler[] flightHandlerLanding = new IStationFlightHandler[] { new StationService(new(), 1, loggerFactory) };
            IControlTowerService controlTowerService = new ControlTowerService(new(), loggerFactory);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, null);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);

            Flight flight = new() { Direction = FlightDirection.Landing };
            FlightServiceMock flightServiceMock = new FlightServiceMock { Flight = flight };

            Assert.True(flightHandlerLanding[0].IsHandlerAvailable);
            controlTowerService.FlightArrived(flightServiceMock);
            Assert.False(flightHandlerLanding[0].IsHandlerAvailable);
        }

        [Fact]
        public void ControlTowerServiceSendsFlightToStationd()
        {
            StationService station = new(new(), 1, loggerFactory);
            FlightServiceMock preFlight = new() { Flight = new() { Direction = FlightDirection.Landing } };

            station.FlightArrived(preFlight);

            IStationFlightHandler[] flightHandlerLanding = new IStationFlightHandler[] { station };
            IControlTowerService controlTowerService = new ControlTowerService(new(), loggerFactory);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, null);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);
            Assert.Equal(station, controlTowerService.LandingStations.First());
            Assert.Equal(preFlight, station.CurrentFlight);
            Assert.False(station.IsHandlerAvailable);

            Flight flight = new() { Direction = FlightDirection.Landing };
            FlightServiceMock flightServiceMock = new() { Flight = flight };
            controlTowerService.FlightArrived(flightServiceMock);

            Assert.False(station.IsHandlerAvailable);
            Assert.Equal(preFlight, station.CurrentFlight);

            Assert.Raises<FlightEventArgs>(eh => station.FlightChanged += eh, eh => station.FlightChanged -= eh, () => preFlight.StopWaiting());

            Assert.False(station.IsHandlerAvailable);
            Assert.Equal(flight, station.CurrentFlight.Flight);
        }

        [Fact]
        public void ControlTowerWillNotSendSameFlightIfTwoStationsClearAtTheSameTime()
        {
            IControlTowerService controlTowerService = new ControlTowerService(new(), loggerFactory);

            IStationService station1 = new StationService(new(), 1, loggerFactory);
            IStationService station2 = new StationService(new(), 1, loggerFactory);

            controlTowerService.ConnectToNextStations(Array.Empty<IStationFlightHandler>(), new IStationFlightHandler[] { station1, station2 });

            FlightServiceMock flight1 = new() { Flight = new() { Direction = FlightDirection.Takeoff } };
            FlightServiceMock flight2 = new() { Flight = new() { Direction = FlightDirection.Takeoff } };
            FlightServiceMock flight3 = new() { Flight = new() { Direction = FlightDirection.Takeoff } };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(flight1, station1.CurrentFlight);
            Assert.True(station2.FlightArrived(flight2));
            Assert.Equal(flight2, station2.CurrentFlight);

            Assert.True(controlTowerService.FlightArrived(flight3));

            Parallel.Invoke(
                () => flight1.StopWaiting(),
                () => flight2.StopWaiting()
            );

            Assert.NotEqual(station1.CurrentFlight, station2.CurrentFlight);
            Assert.True(station1.IsHandlerAvailable ^ station2.IsHandlerAvailable);
        }
    }
}
