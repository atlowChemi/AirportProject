using Common.Models;
using Microsoft.Extensions.Logging;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulator.Services
{
    /// <summary>
    /// Service that returns a random airplane from a set of airplanes.
    /// </summary>
    public class AirplaneSelectorService : IAirplaneSelectorService
    {
        /// <summary>
        /// The airplanes available for flight usage.
        /// </summary>
        private ICollection<Airplane> airplanes;
        /// <summary>
        /// Rhe web client service.
        /// </summary>
        private readonly IWebClientService webClientService;
        /// <summary>
        /// The random data generator.
        /// </summary>
        private readonly IRandomDataService randomDataService;
        /// <summary>
        /// The logger the service will use.
        /// </summary>
        private readonly ILogger<IAirplaneSelectorService> logger;

        /// <summary>
        /// Generate a new instance of the airplane selector service.
        /// </summary>
        /// <param name="webClientService">The Web API service.</param>
        /// <param name="hubConnectionService">The hub connection</param>
        /// <param name="randomDataService">The random data generator.</param>
        /// <param name="logger">The logger the service will use.</param>
        public AirplaneSelectorService(IWebClientService webClientService,
                                       IHubConnectionService hubConnectionService,
                                       IRandomDataService randomDataService,
                                       ILogger<IAirplaneSelectorService> logger)
        {
            this.webClientService = webClientService;
            this.randomDataService = randomDataService;
            this.logger = logger;
            Task.WaitAll(GetAirplanesFromAPI());
            hubConnectionService.Listen<ICollection<Airplane>>("AirplaneUpdates", a => airplanes = a);
        }

        public Airplane GetAirplane()
        {
            if (airplanes == null || airplanes.Count <= 0) return null;
            if (airplanes.Count == 1) return airplanes.First();
            int indexInCollectionBounds = randomDataService.RandomNumber(max: airplanes.Count);
            return airplanes.ElementAtOrDefault(indexInCollectionBounds);
        }

        /// <summary>
        /// Request the airplanes from the UI.
        /// </summary>
        /// <returns>A task representing all the time I was eating better.</returns>
        private async Task GetAirplanesFromAPI()
        {
            airplanes = await webClientService.GetAirplanes();
            if (airplanes is null) {
                logger.LogError("Airplanes returned null from API!");
                airplanes = Array.Empty<Airplane>();
            }
        }
    }
}
