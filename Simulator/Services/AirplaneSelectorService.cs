using Common.Models;
using Simulator.API;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulator.Services
{
    public class AirplaneSelectorService : IAirplaneSelectorService
    {
        private ICollection<Airplane> airplanes;
        private readonly IHubConnectionService hubConnectionService;
        private readonly IRandomDataService randomDataService;

        public AirplaneSelectorService(IHubConnectionService hubConnectionService, IRandomDataService randomDataService)
        {
            this.hubConnectionService = hubConnectionService;
            this.randomDataService = randomDataService;
            Task.WaitAll(GetAirplanesFromHub());
            hubConnectionService.Listen<ICollection<Airplane>>("AirplaneUpdates", a => airplanes = a);
        }

        public Airplane GetAirplane()
        {
            if (airplanes == null || airplanes.Count <= 0) return null;
            if (airplanes.Count == 1) return airplanes.First();
            int indexInCollectionBounds = randomDataService.RandomNumber(max: airplanes.Count);
            return airplanes.ElementAtOrDefault(indexInCollectionBounds);
        }

        private async Task GetAirplanesFromHub()
        {
            airplanes = await hubConnectionService.GetAirplanes();
        }
    }
}
