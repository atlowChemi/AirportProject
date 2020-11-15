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
        private readonly string[] airports = { "JFK", "IST", "SAW", "STN", "LTN", "ATH" };

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
                await randomDataService.RandomDelay();
                Flight flight = await SendFlightToHub();
                action?.Invoke(FlightToMessage(flight));
            }
        }
        private Flight CreateFlight()
        {
            FlightDirection direction = randomDataService.RandomFlightDirection();
            (string from, string to) = PickRandomTarget(direction);
            Airplane airplane = airplaneSelectorService.GetAirplane();
            if (airplane == null) return null;
            return new Flight { Direction = direction, AirplaneId = airplane.Id, From = from, To = to };
        }

        private async Task<Flight> SendFlightToHub()
        {
            Flight flight = CreateFlight();
            return await hubConnectionService.CreateFlight(flight);
        }

        private (string from, string to) PickRandomTarget(FlightDirection direction)
        {
            int randomIndex = randomDataService.RandomNumber(max: airports.Length - 1);
            if (direction == FlightDirection.Landing)
            {
                return (airports[randomIndex], "TLV");
            }
            return ("TLV", airports[randomIndex]);
        }

        private string FlightToMessage(Flight flight)
        {
            string flightDirection = Enum.GetName(typeof(FlightDirection), flight.Direction);
            string flightData = $"{flight.From} > {flight.To}";
            return $"Created {flightDirection} flight: {flightData}";
        }
    }
}