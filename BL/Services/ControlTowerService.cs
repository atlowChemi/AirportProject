using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using Common.Data;

namespace BL.Services
{
    public class ControlTowerService : IControlTowerService
    {
        private readonly object lockObj = new();

        public ControlTower ControlTower { get; init; }

        public IEnumerable<IRelatedToStation> NextStations => ControlTower?.FirstStations;
        public IEnumerable<IStationFlightHandler> LandingStations { get; private set; }
        public IEnumerable<IStationFlightHandler> TakeoffStations { get; private set; }
        private MyQueue<Flight> LandingFlights { get; set; }
        private MyQueue<Flight> TakeoffFlights { get; set; }
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
            MyQueue<Flight> relevantFlights = GetRelevantFlights(flightService.Flight.Direction);
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

            if (LandingFlights.TryDequeue(out Flight landingFlight))
            {
                IFlightService flightService = new FlightService(landingFlight);
                SendFlightToRelvantStation(flightService, true);
            }
            if (TakeoffFlights.TryDequeue(out Flight takeoffFlight))
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

            LandingFlights = new MyQueue<Flight>(landingFlights);
            TakeoffFlights = new MyQueue<Flight>(takeoffFlights);
        }

        private void AddFlightToWaitingList(Flight flight, bool fromWaitingList = false)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            MyQueue<Flight> relevantFlights = GetRelevantFlights(flight.Direction);
            if (fromWaitingList) relevantFlights.AddToBegining(flight);
            else relevantFlights.Enqueue(flight);

        }

        private void SendFlightToRelvantStation(IFlightService flightService, bool isFromWaitingList = false)
        {
            // TODO : If the flight has started out from the queue, we might call it again?
            if (flightService is null) throw new ArgumentNullException(nameof(flightService), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            IEnumerable<IStationFlightHandler> relevantFirstStations = GetRelevantFlightHandler(flightService.Flight.Direction);

            IStationFlightHandler avaialabeStation = relevantFirstStations?.FirstOrDefault(ss => ss.IsHandlerAvailable);
            if (avaialabeStation is not null && avaialabeStation.IsHandlerAvailable && avaialabeStation.FlightArrived(flightService))
            {
                FlightChanged?.Invoke(this, new FlightEventArgs(flightService.Flight, null, avaialabeStation.Station));
            }
            else AddFlightToWaitingList(flightService.Flight, isFromWaitingList);
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
            lock (lockObj)
            {
                if (isLandingStation && LandingFlights.TryDequeue(out Flight landingFlight))
                {
                    flightService = new FlightService(landingFlight);
                }
                else if (isTakeoffStation && TakeoffFlights.TryDequeue(out Flight takeoffFlight))
                {
                    flightService = new FlightService(takeoffFlight);
                }
            }
            if (flightService is not null)
            {
                SendFlightToRelvantStation(flightService, true);
            }
        }

        private IEnumerable<IStationFlightHandler> GetRelevantFlightHandler(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;

        private MyQueue<Flight> GetRelevantFlights(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingFlights : TakeoffFlights;
    }
}
