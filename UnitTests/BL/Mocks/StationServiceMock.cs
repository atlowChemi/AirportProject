using Common.Events;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;

namespace UnitTests.BL.Mocks
{
    public class StationServiceMock : IStationService
    {
        public IFlightService CurrentFlight => throw new NotImplementedException();

        public int WaitingTimeMS => throw new NotImplementedException();

        public Station Station => throw new NotImplementedException();

        public bool IsHandlerAvailable => throw new NotImplementedException();

        public IEnumerable<IRelatedToStation> NextStations => throw new NotImplementedException();

        public IEnumerable<IStationFlightHandler> TakeoffStations => throw new NotImplementedException();

        public IEnumerable<IStationFlightHandler> LandingStations => throw new NotImplementedException();

        public event EventHandler<FlightEventArgs> FlightChanged;

        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations)
        {
            throw new NotImplementedException();
        }

        public bool FlightArrived(IFlightService flight)
        {
            throw new NotImplementedException();
        }

        public void RaiseFlightChanged()
        {
            Flight flight = new() { From = "MOCK", To = "MOCK" };
            Station stationFrom = new() { Name = "FromMock" };
            Station stationTo = new() { Name = "ToMock" };

            FlightChanged?.Invoke(this, new(flight, stationFrom, stationTo));
        }

    }
}
