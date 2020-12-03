using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Events;
using Common.Interfaces;
using Common.Models;
using Common.Data;
using Microsoft.Extensions.Logging;

namespace BL.Services
{
    /// <summary>
    /// Logical wrapper of control tower.
    /// </summary>
    public class ControlTowerService : IControlTowerService
    {
        /// <summary>
        /// Enable locking multi-threads, to avoid Malaysian issues.
        /// </summary>
        private readonly object lockObj = new();
        /// <summary>
        /// The logger factory for this service.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;
        /// <summary>
        /// The logger for this service.
        /// </summary>
        private readonly ILogger<IControlTowerService> logger;

        public event EventHandler<FlightEventArgs> FlightChanged;
        public ControlTower ControlTower { get; init; }

        public IEnumerable<IRelatedToStation> NextStations => ControlTower?.FirstStations;
        public IEnumerable<IStationFlightHandler> LandingStations { get; private set; }
        public IEnumerable<IStationFlightHandler> TakeoffStations { get; private set; }
        /// <summary>
        /// A Queue to handle flights waiting to land.
        /// </summary>
        private MyQueue<Flight> LandingFlights { get; set; }
        /// <summary>
        /// A Queue to handle flights waiting to takeoff.
        /// </summary>
        private MyQueue<Flight> TakeoffFlights { get; set; }

        /// <summary>
        /// Generate a new instance of the control tower service.
        /// </summary>
        /// <param name="controlTower">The control tower this instance should handle.</param>
        /// <param name="loggerFactory">The logger for this service.</param>
        /// <exception cref="ArgumentNullException">The control tower was null.</exception>
        public ControlTowerService(ControlTower controlTower, ILoggerFactory loggerFactory)
        {
            ControlTower = controlTower ?? throw new ArgumentNullException(nameof(controlTower));
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            logger = loggerFactory.CreateLogger<IControlTowerService>();
            InitFlightQueues();
            logger.LogInformation("Generated control tower service", controlTower.Name);
        }


        public bool FlightArrived(IFlightService flightService)
        {
            if (flightService is null) throw new ArgumentNullException(nameof(flightService), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            MyQueue<Flight> relevantFlights = GetRelevantFlights(flightService.Flight.Direction);
            if (relevantFlights.Count == 0) SendFlightToRelvantStation(flightService);
            else AddFlightToWaitingList(flightService.Flight);
            logger.LogInformation("Flight added to the control tower.");
            return true;
        }

        public void ConnectToNextStations(IEnumerable<IStationFlightHandler> landingStations, IEnumerable<IStationFlightHandler> takeoffStations)
        {
            SignOutOfAllStationsEvents();
            LandingStations = landingStations;
            TakeoffStations = takeoffStations;
            SignupToAllStationsEvents();

            logger.LogInformation("Control tower service - next stations updated.");
            ILogger<IFlightService> flightLogger = loggerFactory.CreateLogger<IFlightService>();
            if (LandingFlights.TryDequeue(out Flight landingFlight))
            {
                IFlightService flightService = new FlightService(landingFlight, flightLogger);
                SendFlightToRelvantStation(flightService, true);
            }
            if (TakeoffFlights.TryDequeue(out Flight takeoffFlight))
            {
                IFlightService flightService = new FlightService(takeoffFlight, flightLogger);
                SendFlightToRelvantStation(flightService, true);
            }
        }

        /// <summary>
        /// Initialize the queues of the flights from the DB.
        /// </summary>
        private void InitFlightQueues()
        {
            IEnumerable<Flight> waitingFlights = ControlTower?.FlightsWaiting?.Where(f => f.History?.Count <= 0) ?? Enumerable.Empty<Flight>();
            IEnumerable<Flight> landingFlights = waitingFlights.Where(f => f.Direction == FlightDirection.Landing);
            IEnumerable<Flight> takeoffFlights = waitingFlights.Where(f => f.Direction == FlightDirection.Takeoff);

            LandingFlights = new MyQueue<Flight>(landingFlights);
            TakeoffFlights = new MyQueue<Flight>(takeoffFlights);
        }
        /// <summary>
        /// Add a flight to the waiting list.
        /// </summary>
        /// <param name="flight">The flight that shoul be added to the waiting list.</param>
        /// <param name="fromWaitingList">Wether the flight has already been in waiting list or not.</param>
        /// <exception cref="ArgumentNullException">Flight sent was null.</exception>
        private void AddFlightToWaitingList(Flight flight, bool fromWaitingList = false)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            MyQueue<Flight> relevantFlights = GetRelevantFlights(flight.Direction);
            if (fromWaitingList) relevantFlights.AddToBegining(flight);
            else relevantFlights.Enqueue(flight);
            logger.LogInformation("Flight was not sent, and is now in waiting list", flight);

        }
        /// <summary>
        /// Transfer a flight to the next relevant service.
        /// </summary>
        /// <param name="flightService">The service that handles the flight during it travel of the airport.</param>
        /// <param name="isFromWaitingList">Wethear the flight has come from waiting list or not.</param>
        /// <exception cref="ArgumentNullException">The flight service was null.</exception>
        private void SendFlightToRelvantStation(IFlightService flightService, bool isFromWaitingList = false)
        {
            if (flightService is null) throw new ArgumentNullException(nameof(flightService), "A flight cannot arrive to the control tower as null! This is not Malaysia Airlines!");
            IEnumerable<IStationFlightHandler> relevantFirstStations = GetRelevantFlightHandler(flightService.Flight.Direction);

            IStationFlightHandler avaialabeStation = relevantFirstStations?.FirstOrDefault(ss => ss.IsHandlerAvailable);
            if (avaialabeStation is not null && avaialabeStation.IsHandlerAvailable && avaialabeStation.FlightArrived(flightService))
            {
                logger.LogInformation("Flight left control tower towards the first station", flightService.Flight, avaialabeStation.Station);
                FlightChanged?.Invoke(this, new FlightEventArgs(flightService.Flight, null, avaialabeStation.Station));
            }
            else AddFlightToWaitingList(flightService.Flight, isFromWaitingList);
        }
        /// <summary>
        /// Remove listeners from all the stations, in order to replace them.
        /// </summary>
        private void SignOutOfAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged -= FlightHandler_FlightChanged;
            }
        }
        /// <summary>
        /// Start listening to all the stations, in order to transfer flights if a station has turned available.
        /// </summary>
        private void SignupToAllStationsEvents()
        {
            IEnumerable<IStationFlightHandler> emptyFallback = Enumerable.Empty<IStationFlightHandler>();
            IEnumerable<IStationFlightHandler> allStations = (LandingStations ?? emptyFallback).Concat(TakeoffStations ?? emptyFallback);
            foreach (IStationFlightHandler item in allStations)
            {
                item.FlightChanged += FlightHandler_FlightChanged;
            }
        }
        /// <summary>
        /// Event handler for the event of a flight chnaged - and possibly available station.
        /// </summary>
        /// <param name="sender">The station which raised the event.</param>
        /// <param name="e">The arguments of the event.</param>
        /// <exception cref="ArgumentException">The event was raised by a none IFlightHandler, and therefore is unusable.</exception>
        private void FlightHandler_FlightChanged(object sender, EventArgs e)
        {
            if (sender is not IStationFlightHandler flightHandler)
                throw new ArgumentException("Sender must be a station service!", nameof(sender));
            bool isLandingStation = LandingStations?.Contains(flightHandler) ?? false;
            bool isTakeoffStation = TakeoffStations?.Contains(flightHandler) ?? false;

            IFlightService flightService = null;
            ILogger<IFlightService> flightLogger = loggerFactory.CreateLogger<IFlightService>();
            lock (lockObj)
            {
                if (isLandingStation && LandingFlights.TryDequeue(out Flight landingFlight))
                {
                    flightService = new FlightService(landingFlight, flightLogger);
                }
                else if (isTakeoffStation && TakeoffFlights.TryDequeue(out Flight takeoffFlight))
                {
                    flightService = new FlightService(takeoffFlight, flightLogger);
                }
            }
            if (flightService is not null)
            {
                SendFlightToRelvantStation(flightService, true);
            }
        }
        /// <summary>
        /// Get the relevant Flight handlers.
        /// </summary>
        /// <param name="direction">The direction to get the flight handlers for.</param>
        /// <returns>A <see cref="IEnumerable{IStationFlightHandler}"/> of the next stations.</returns>
        private IEnumerable<IStationFlightHandler> GetRelevantFlightHandler(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingStations : TakeoffStations;
        /// <summary>
        /// Get the relevant flight Queue.
        /// </summary>
        /// <param name="direction">The direction to get the flight of.</param>
        /// <returns>A <see cref="MyQueue{Flight}"/> of the flights by given direction.</returns>
        private MyQueue<Flight> GetRelevantFlights(FlightDirection direction) =>
            direction == FlightDirection.Landing ? LandingFlights : TakeoffFlights;
    }
}
