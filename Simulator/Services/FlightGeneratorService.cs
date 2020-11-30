using Common.Constants;
using Common.Enums;
using Common.Models;
using Simulator.API;
using System;
using System.Threading.Tasks;

namespace Simulator.Services
{
    public class FlightGeneratorService : IFlightGeneratorService
    {
        private readonly IRandomDataService randomDataService;
        private readonly IHubConnectionService hubConnectionService;
        private readonly IAirplaneSelectorService airplaneSelectorService;

        public FlightGeneratorService(IRandomDataService randomDataService,
            IHubConnectionService hubConnectionService,
            IAirplaneSelectorService airplaneSelectorService)
        {
            this.randomDataService = randomDataService;
            this.hubConnectionService = hubConnectionService;
            this.airplaneSelectorService = airplaneSelectorService;
        }

        public async Task StartGeneratingRandomFlights(Action<string> action)
        {
            for (; ; )
            {
                await randomDataService.RandomDelay(
                    Constants.MINIMAL_FLIGHT_CREATION_DELAY,
                    Constants.MAXIMAL_FLIGHT_CREATION_DELAY);
                Flight flight = await SendFlightToHub();
                action?.Invoke(FlightToMessage(flight));
            }
        }
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

        private async Task<Flight> SendFlightToHub()
        {
            Flight flight = CreateFlight();
            await hubConnectionService.CreateFlight(flight);
            return flight;
        }

        private (string from, string to) PickRandomTarget(FlightDirection direction)
        {
            string randomTarget = randomDataService.RandomFlightTarget();
            if (direction == FlightDirection.Landing)
            {
                return (randomTarget, Constants.CONTROL_TOWER_NAME);
            }
            return (Constants.CONTROL_TOWER_NAME, randomTarget);
        }

        private static string FlightToMessage(Flight flight)
        {
            string flightDirection = Enum.GetName(typeof(FlightDirection), flight.Direction);
            string flightData = $"{flight.From} > {flight.To}";
            return $"Created {flightDirection} flight: {flightData} for { flight.PlannedTime.ToLongTimeString() }";
        }
    }
}