using BL.Services;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System;
using System.Linq;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class ControlTowerTests
    {
        [Fact]
        public void ControlTowerServiceShouldThrowIfControlTowerIsNull()
        {
            Assert.Throws<ArgumentNullException>("controlTower", () => new ControlTowerService(null));
        }

        [Fact]
        public void ControlTowerServiceShouldHaveExpectedControlTower()
        {
            ControlTower controlTower = new ControlTower();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower);

            Assert.Equal(controlTower, controlTowerService.ControlTower);
        }

        [Fact]
        public void ControlTowerServiceShouldHaveExpectedNextStations()
        {
            IFlightHandler[] flightHandlerLanding = new IFlightHandler[] { new StationService(new Station(), 1) };
            IFlightHandler[] flightHandlerTakeoff = new IFlightHandler[] { new StationService(new Station(), 1) };
            ControlTower controlTower = new ControlTower();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, flightHandlerTakeoff);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);
            Assert.Equal(flightHandlerTakeoff, controlTowerService.TakeoffStations);
        }

        [Fact]
        public void ControlTowerServiceThrowsIfNullFlight()
        {
            ControlTower controlTower = new ControlTower();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower);
            Assert.Throws<ArgumentNullException>("flightService", () => controlTowerService.FlightArrived(null));
        }

        [Fact]
        public void ControlTowerServiceSendsFlightToStation()
        {
            IFlightHandler[] flightHandlerLanding = new IFlightHandler[] { new StationService(new Station(), 1) };
            ControlTower controlTower = new ControlTower();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, null);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);

            Flight flight = new Flight { Direction = FlightDirection.Landing };
            FlightServiceMock flightServiceMock = new FlightServiceMock { Flight = flight };

            Assert.True(flightHandlerLanding[0].IsHandlerAvailable);
            controlTowerService.FlightArrived(flightServiceMock);
            Assert.False(flightHandlerLanding[0].IsHandlerAvailable);
        }

        [Fact]
        public void ControlTowerServiceSendsFlightToStationd()
        {
            StationService station = new StationService(new Station(), 1);
            FlightServiceMock preFlight = new FlightServiceMock { Flight = new Flight { Direction = FlightDirection.Landing } };
            
            station.FlightArrived(preFlight);

            IFlightHandler[] flightHandlerLanding = new IFlightHandler[] { station };
            ControlTower controlTower = new ControlTower();
            IControlTowerService controlTowerService = new ControlTowerService(controlTower);
            controlTowerService.ConnectToNextStations(flightHandlerLanding, null);

            Assert.Equal(flightHandlerLanding, controlTowerService.LandingStations);
            Assert.Equal(station, controlTowerService.LandingStations.First());
            Assert.Equal(preFlight, station.CurrentFlight);
            Assert.False(station.IsHandlerAvailable);

            Flight flight = new Flight { Direction = FlightDirection.Landing };
            FlightServiceMock flightServiceMock = new FlightServiceMock { Flight = flight };
            controlTowerService.FlightArrived(flightServiceMock);

            Assert.False(station.IsHandlerAvailable);
            Assert.Equal(preFlight, station.CurrentFlight);

            Assert.Raises<EventArgs>(eh => station.AvailabiltyChange += eh, eh => station.AvailabiltyChange -= eh, () => preFlight.StopWaiting());

            Assert.False(station.IsHandlerAvailable);
            Assert.Equal(flight, station.CurrentFlight.Flight);
        }
    }
}
