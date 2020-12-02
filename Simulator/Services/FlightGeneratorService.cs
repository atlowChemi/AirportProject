using Common.Constants;
using Common.Enums;
using Common.Models;
using Simulator.API;
using System;
using System.Threading.Tasks;

namespace Simulator.Services
{
    /// <summary>
    /// Service that generates random flights.
    /// </summary>
    public class FlightGeneratorService : IFlightGeneratorService
    {
        /// <summary>
        /// The random data generator.
        /// </summary>
        private readonly IRandomDataService randomDataService;
        /// <summary>
        /// The WebAPI client service.
        /// </summary>
        private readonly IWebClientService webClientService;
        /// <summary>
        /// The airpleane selector service.
        /// </summary>
        private readonly IAirplaneSelectorService airplaneSelectorService;

        /// <summary>
        /// Generate a new flight generator service.
        /// </summary>
        /// <param name="randomDataService">The random data generator.</param>
        /// <param name="webClientService">The WebAPI client service.</param>
        /// <param name="airplaneSelectorService">The airpleane selector service.</param>
        public FlightGeneratorService(IRandomDataService randomDataService,
            IWebClientService webClientService,
            IAirplaneSelectorService airplaneSelectorService)
        {
            this.randomDataService = randomDataService;
            this.webClientService = webClientService;
            this.airplaneSelectorService = airplaneSelectorService;
        }

        public async Task StartGeneratingRandomFlights(Action<string> action)
        {
            for (; ; )
            {
                await randomDataService.RandomDelay(
                    Constants.MINIMAL_FLIGHT_CREATION_DELAY,
                    Constants.MAXIMAL_FLIGHT_CREATION_DELAY);
                Flight flight = await SendFlightToAPI();
                action?.Invoke(FlightToMessage(flight));
            }
        }
        
        /// <summary>
        /// Build a random flight.
        /// </summary>
        /// <returns>Newly generated random flight.</returns>
        private Flight CreateFlight()
        {
            FlightDirection direction = randomDataService.RandomFlightDirection();
            (string from, string to) = PickRandomTarget(direction);
            Airplane airplane = airplaneSelectorService.GetAirplane();
            int rndDelay = randomDataService.RandomNumber(Constants.MINIMAL_FLIGHT_DELAY, Constants.MAXIMAL_FLIGHT_DELAY);
            DateTime plannedTime = DateTime.Now.AddSeconds(rndDelay);
            if (airplane is null) return null;
            return new Flight { Direction = direction, AirplaneId = airplane.Id, From = from, To = to, PlannedTime = plannedTime };
        }
        /// <summary>
        /// Send the flight to API. 
        /// </summary>
        /// <returns>The flight from server.</returns>
        private async Task<Flight> SendFlightToAPI()
        {
            Flight flight = CreateFlight();
            await webClientService.CreateFlight(flight);
            return flight;
        }
        /// <summary>
        /// Pick and create a random target.
        /// </summary>
        /// <param name="direction">The direction of the flight.</param>
        /// <returns>To and From with airport names.</returns>
        private (string from, string to) PickRandomTarget(FlightDirection direction)
        {
            string randomTarget = randomDataService.RandomFlightTarget();
            if (direction == FlightDirection.Landing)
            {
                return (randomTarget, Constants.CONTROL_TOWER_NAME);
            }
            return (Constants.CONTROL_TOWER_NAME, randomTarget);
        }
        /// <summary>
        /// Turn a flight event into message.
        /// </summary>
        /// <param name="flight">Flight to stringify.</param>
        /// <returns>Representing string of flight.</returns>
        private static string FlightToMessage(Flight flight)
        {
            string flightDirection = Enum.GetName(typeof(FlightDirection), flight.Direction);
            string flightData = $"{flight.From} > {flight.To}";
            return $"Created {flightDirection} flight: {flightData} for { flight.PlannedTime.ToLongTimeString() }";
        }
    }
}