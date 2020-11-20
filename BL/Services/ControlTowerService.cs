using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Interfaces;
using Common.Models;

namespace BL.Services
{
    public class ControlTowerService : IControlTowerService
    {
        public ControlTower ControlTower { get; init; }

        public IEnumerable<IRelatedToStation> NextStations => ControlTower?.FirstStations;
        public IEnumerable<IFlightHandler> LandingStations { get; private set; }
        public IEnumerable<IFlightHandler> TakeoffStations { get; private set; }
        private Queue<Flight> LandingFlights { get; set; }
        private Queue<Flight> TakeoffFlights { get; set; }


        public ControlTowerService(ControlTower controlTower)
        {
            if (controlTower is null) throw new ArgumentNullException(nameof(controlTower));
            ControlTower = controlTower;
            InitFlightQueues();
            SignupToAllStationsEvents();
        }

        public void FlightArrived(Flight flight)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            Queue<Flight> relevantFlights = GetRelevantFlights(flight.Direction);
            if (relevantFlights.Count == 0)
            {
                SendFlightToRelvantStation(flight);
            }
            else
            {
                AddFlightToWaitingList(flight);
            }
        }

        public void ConnectToNextStations(IEnumerable<IFlightHandler> landingStations, IEnumerable<IFlightHandler> takeoffStations)
        {
            SignupOutOfAllStationsEvents();
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
            SignupToAllStationsEvents();
        }

        private void InitFlightQueues()
        {
            IEnumerable<Flight> emptyFallback = Enumerable.Empty<Flight>();
            IEnumerable<Flight> landingFlights = ControlTower?.FlightsWaiting?.Where(f => f.Direction == FlightDirection.Landing) ?? emptyFallback;
            IEnumerable<Flight> takeoffFlights = ControlTower?.FlightsWaiting?.Where(f => f.Direction == FlightDirection.Landing) ?? emptyFallback;

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
            if (relevantFlights.TryPeek(out Flight fl) && flight == fl)
            {
                relevantFlights.Dequeue();
            }
        }

        private void SendFlightToRelvantStation(Flight flight, bool isFromWaitingList = false)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            IEnumerable<IFlightHandler> relevantFirstStations = GetRelevantFlightHandler(FlightDirection.Landing);

            IFlightHandler avaialabeStation = relevantFirstStations.FirstOrDefault(ss => ss.IsHandlerAvailable);
            IFlightService flightService = new FlightService(flight);
            if ((avaialabeStation is null || !avaialabeStation.FlightArrived(flightService)) && !isFromWaitingList)
            {
                AddFlightToWaitingList(flight);
            }
            else if (isFromWaitingList)
            {
                RemoveFlightFromWaitingList(flight);
            }
        }

        private void SignupOutOfAllStationsEvents()
        {
            IEnumerable<IFlightHandler> emptyFallback = Enumerable.Empty<IFlightHandler>();
            IEnumerable<IFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IFlightHandler item in allStations)
            {
                item.AvailabiltyChange -= FlightHandler_AvailabilityChanged;
            }
        }

        private void SignupToAllStationsEvents()
        {
            IEnumerable<IFlightHandler> emptyFallback = Enumerable.Empty<IFlightHandler>();
            IEnumerable<IFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IFlightHandler item in allStations)
            {
                item.AvailabiltyChange += FlightHandler_AvailabilityChanged;
            }
        }

        private void FlightHandler_AvailabilityChanged(object sender, EventArgs e)
        {
            if (sender is not IFlightHandler flightHandler)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));
            bool isLandingStation = LandingStations?.Contains(flightHandler) ?? false;
            bool isTakeoffStation = TakeoffStations?.Contains(flightHandler) ?? false;

            if (isLandingStation && LandingFlights.TryPeek(out Flight landingFlight))
            {
                SendFlightToRelvantStation(landingFlight, true);
            }
            else if (isTakeoffStation && TakeoffFlights.TryPeek(out Flight takeoffFlight))
            {
                SendFlightToRelvantStation(takeoffFlight, true);
            }
        }

        private IEnumerable<IFlightHandler> GetRelevantFlightHandler(FlightDirection direction) => 
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;

        private Queue<Flight> GetRelevantFlights(FlightDirection direction) => 
            direction == FlightDirection.Landing ? LandingFlights : TakeoffFlights;
    }
}
