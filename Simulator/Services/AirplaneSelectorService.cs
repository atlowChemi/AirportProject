using Common.Models;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulator.Services
{
    public class AirplaneSelectorService : IAirplaneSelectorService
    {
        private ICollection<Airplane> airplanes;
        private readonly IHubConnectionService hubConnectionService;
        private readonly IWebClientService webClientService;
        private readonly IRandomDataService randomDataService;

        public AirplaneSelectorService(IWebClientService webClientService, IHubConnectionService hubConnectionService, IRandomDataService randomDataService)
        {
            this.webClientService = webClientService;
            this.hubConnectionService = hubConnectionService;
            this.randomDataService = randomDataService;
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

        private async Task GetAirplanesFromAPI()
        {
            airplanes = await webClientService.GetAirplanes() ?? Array.Empty<Airplane>();
        }
    }
}
