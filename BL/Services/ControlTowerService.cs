using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;

namespace BL.Services
{
    public class ControlTowerService : IControlTowerService
    {
        public ControlTower ControlTower { get; init; }

        public IEnumerable<IRelatedToStation> NextStations => ControlTower?.FirstStations;
        public IEnumerable<IStationFlightHandler> LandingStations { get; private set; }
        public IEnumerable<IStationFlightHandler> TakeoffStations { get; private set; }
        private Queue<Flight> LandingFlights { get; set; }
        private Queue<Flight> TakeoffFlights { get; set; }
        public event EventHandler<FlightEventArgs> FlightChanged;


        public ControlTowerService(ControlTower controlTower)
        {
            if (controlTower is null) throw new ArgumentNullException(nameof(controlTower));
            ControlTower = controlTower;
            InitFlightQueues();
            SignupToAllStationsEvents();
        }


        public bool FlightArrived(IFlightService flightService)
        {
            if (flightService is null) throw new ArgumentNullException(nameof(flightService), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            Queue<Flight> relevantFlights = GetRelevantFlights(flightService.Flight.Direction);
            if (relevantFlights.Count == 0) SendFlightToRelvantStation(flightService);
            else AddFlightToWaitingList(flightService.Flight);
            return true;
        }

        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations)
        {
            SignupOutOfAllStationsEvents();
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
            SignupToAllStationsEvents();

            if (LandingFlights.TryPeek(out Flight landingFlight))
            {
                IFlightService flightService = new FlightService(landingFlight);
                SendFlightToRelvantStation(flightService, true);
            }
            if (TakeoffFlights.TryPeek(out Flight takeoffFlight))
            {
                IFlightService flightService = new FlightService(takeoffFlight);
                SendFlightToRelvantStation(flightService, true);
            }
        }

        private void InitFlightQueues()
        {
            IEnumerable<Flight> waitingFlights = ControlTower?.FlightsWaiting?.Where(f => f.History?.Count <= 0) ?? Enumerable.Empty<Flight>();
            IEnumerable<Flight> landingFlights = waitingFlights.Where(f => f.Direction == FlightDirection.Landing);
            IEnumerable<Flight> takeoffFlights = waitingFlights.Where(f => f.Direction == FlightDirection.Takeoff);

            LandingFlights = new Queue<Flight>(landingFlights);
            TakeoffFlights = new Queue<Flight>(takeoffFlights);
        }

        private void AddFlightToWaitingList(Flight flight)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            Queue<Flight> relevantFlights = GetRelevantFlights(flight.Direction);
            ControlTower?.FlightsWaiting?.Add(flight);
            relevantFlights.Enqueue(flight);
        }

        private void RemoveFlightFromWaitingList(Flight flight)
        {
            if (flight is null) return;
            ControlTower?.FlightsWaiting?.Remove(flight);
            Queue<Flight> relevantFlights = GetRelevantFlights(flight.Direction);
            if (relevantFlights.TryPeek(out Flight fl) && flight.Id == fl.Id)
            {
                relevantFlights.Dequeue();
            }
        }

        private void SendFlightToRelvantStation(IFlightService flightService, bool isFromWaitingList = false)
        {
            if (flightService is null) throw new ArgumentNullException(nameof(flightService), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            IEnumerable<IStationFlightHandler> relevantFirstStations = GetRelevantFlightHandler(FlightDirection.Landing);

            IStationFlightHandler avaialabeStation = relevantFirstStations?.FirstOrDefault(ss => ss.IsHandlerAvailable);
            if (avaialabeStation is not null && avaialabeStation.FlightArrived(flightService))
            {
                FlightChanged?.Invoke(this, new FlightEventArgs(flightService.Flight, null, avaialabeStation.Station));
                if (isFromWaitingList) RemoveFlightFromWaitingList(flightService.Flight);
            }
            else if (!isFromWaitingList)
            {
                AddFlightToWaitingList(flightService.Flight);
            }
        }

        private void SignupOutOfAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged -= FlightHandler_FlightChanged;
            }
        }

        private void SignupToAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged += FlightHandler_FlightChanged;
            }
        }

        private void FlightHandler_FlightChanged(object sender, EventArgs e)
        {
            if (sender is not IStationFlightHandler flightHandler)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));
            bool isLandingStation = LandingStations?.Contains(flightHandler) ?? false;
            bool isTakeoffStation = TakeoffStations?.Contains(flightHandler) ?? false;

            IFlightService flightService = null;
            if (isLandingStation && LandingFlights.TryPeek(out Flight landingFlight))
            {
                flightService = new FlightService(landingFlight);
            }
            else if (isTakeoffStation && TakeoffFlights.TryPeek(out Flight takeoffFlight))
            {
                flightService = new FlightService(takeoffFlight);
            }
            if (flightService is not null)
            {
                SendFlightToRelvantStation(flightService, true);
            }
        }

        private IEnumerable<IStationFlightHandler> GetRelevantFlightHandler(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;

        private Queue<Flight> GetRelevantFlights(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingFlights : TakeoffFlights;
    }
}
