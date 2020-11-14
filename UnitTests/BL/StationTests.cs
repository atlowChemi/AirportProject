using BL.Models;
using Common.Enums;
using Common.Interfaces;
using System;
using UnitTests.BL.Mocks;
using Xunit;

namespace UnitTests.BL
{
    public class StationTests
    {
        [Fact]
        public void StationRejectsFlightWhileBusy()
        {
            IStation station = new Station(0);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Landing };
            FlightMock flight2 = new FlightMock { Direction = FlightDirection.Landing };

            Assert.True(station.FlightArrived(flight1));
            Assert.Equal(station.CurrentFlight, flight1);
            Assert.False(station.IsStationAvailable);
            Assert.False(station.FlightArrived(flight2));
            Assert.Equal(station.CurrentFlight, flight1);
        }

        [Fact]
        public void StationAcceptsFlightWhenAvailable()
        {
            IStation station = new Station(0);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Landing };
            FlightMock flight2 = new FlightMock { Direction = FlightDirection.Landing };

            Assert.True(station.FlightArrived(flight1));
            Assert.False(station.IsStationAvailable);
            Assert.Equal(station.CurrentFlight, flight1);

            flight1.StopWaiting();
            Assert.Null(station.CurrentFlight);
            Assert.True(station.IsStationAvailable);
            Assert.True(station.FlightArrived(flight2));
            Assert.Equal(station.CurrentFlight, flight2);
        }

        [Fact]
        public void PlaneWaitInStationIfNextStationOneIsNotAvailable()
        {
            IStation station1 = new Station(0);
            IStation station2 = new Station(0);
            station1.LandingStations.Add(station2);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Landing };
            FlightMock flight2 = new FlightMock { Direction = FlightDirection.Landing };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(station1.CurrentFlight, flight1);
            
            Assert.True(station2.FlightArrived(flight2));
            Assert.Equal(station2.CurrentFlight, flight2);

            flight1.StopWaiting();

            Assert.False(station1.IsStationAvailable);
            Assert.Equal(station1.CurrentFlight, flight1);
            Assert.NotEqual(station2.CurrentFlight, flight1);
            Assert.Equal(station2.CurrentFlight, flight2);
        }

        [Fact]
        public void StationMarksAsAvailableWhenPlaneDeparts()
        {
            IStation station1 = new Station(0);
            IStation station2 = new Station(0);
            station1.LandingStations.Add(station2);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Landing };

            Assert.True(station1.FlightArrived(flight1));
            Assert.Equal(station1.CurrentFlight, flight1);
            
            Assert.Null(station2.CurrentFlight);

            var evt = Assert.Raises<EventArgs>(xHandler => station1.AvailabiltyChange += xHandler, xHandler => station1.AvailabiltyChange -= xHandler, () => flight1.StopWaiting());

            Assert.NotNull(evt);
            Assert.Equal(station1, evt.Sender);
            Assert.Equal(EventArgs.Empty, evt.Arguments);

            Assert.True(station1.IsStationAvailable);
            Assert.Null(station1.CurrentFlight);
            Assert.Equal(station2.CurrentFlight, flight1);
        }

        [Fact]
        public void StationTurnsAvailableIfNoContinuationStation()
        {
            IStation station1 = new Station(0);
            IStation station2 = new Station(0);
            station1.LandingStations.Add(station2);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Landing };
            FlightMock flight2 = new FlightMock { Direction = FlightDirection.Landing };

            Assert.True(station2.FlightArrived(flight1));
            Assert.True(station1.FlightArrived(flight2));

            Assert.False(station2.IsStationAvailable);
            Assert.Equal(station2.CurrentFlight, flight1);

            Assert.False(station1.IsStationAvailable);
            Assert.Equal(station1.CurrentFlight, flight2);

            flight2.StopWaiting();
            Assert.False(station1.IsStationAvailable);
            Assert.Equal(station1.CurrentFlight, flight2);

            flight1.StopWaiting();
            Assert.True(station1.IsStationAvailable);
            Assert.False(station2.IsStationAvailable);
            Assert.Equal(station2.CurrentFlight, flight2);
        }

        [Fact]
        public void StationSendsPlainToCorrectNextStation()
        {
            IStation stationStart = new Station(0);
            IStation stationLand = new Station(0);
            IStation stationTakoff = new Station(0);
            stationStart.LandingStations.Add(stationLand);
            stationStart.TakeoffStations.Add(stationTakoff);

            FlightMock flightLanding = new FlightMock { Direction = FlightDirection.Landing };
            FlightMock flightTakoeff = new FlightMock { Direction = FlightDirection.Takeoff };

            Assert.True(stationStart.FlightArrived(flightLanding));
            Assert.False(stationStart.IsStationAvailable);
            Assert.Equal(stationStart.CurrentFlight, flightLanding);

            Assert.True(stationLand.IsStationAvailable);
            Assert.True(stationTakoff.IsStationAvailable);

            flightLanding.StopWaiting();

            Assert.True(stationStart.IsStationAvailable);
            Assert.False(stationLand.IsStationAvailable);
            Assert.Equal(stationLand.CurrentFlight, flightLanding);

            Assert.True(stationStart.FlightArrived(flightTakoeff));

            Assert.False(stationStart.IsStationAvailable);
            Assert.Equal(stationStart.CurrentFlight, flightTakoeff);

            flightTakoeff.StopWaiting();

            Assert.True(stationStart.IsStationAvailable);
            Assert.False(stationTakoff.IsStationAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flightTakoeff);
        }

        [Fact]
        public void StationDowsNotSendPlainToIncorrectNextStation()
        {
            IStation stationStart = new Station(0);
            IStation stationLand = new Station(0);
            IStation stationTakoff = new Station(0);
            stationStart.LandingStations.Add(stationLand);
            stationStart.TakeoffStations.Add(stationTakoff);

            FlightMock flight1 = new FlightMock { Direction = FlightDirection.Takeoff };
            FlightMock flight2 = new FlightMock { Direction = FlightDirection.Takeoff };

            Assert.True(stationStart.FlightArrived(flight1));
            Assert.False(stationStart.IsStationAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight1);

            Assert.True(stationLand.IsStationAvailable);
            Assert.True(stationTakoff.IsStationAvailable);

            flight1.StopWaiting();

            Assert.True(stationStart.IsStationAvailable);
            Assert.False(stationTakoff.IsStationAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flight1);

            Assert.True(stationStart.FlightArrived(flight2));
            Assert.False(stationStart.IsStationAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight2);

            flight2.StopWaiting();

            Assert.False(stationStart.IsStationAvailable);
            Assert.Equal(stationStart.CurrentFlight, flight2);
            Assert.False(stationTakoff.IsStationAvailable);
            Assert.Equal(stationTakoff.CurrentFlight, flight1);
            Assert.True(stationLand.IsStationAvailable);
            Assert.Null(stationLand.CurrentFlight);
        }
    }
}
