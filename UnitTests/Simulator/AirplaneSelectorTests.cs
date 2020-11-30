using Common.Models;
using Simulator.API;
using Simulator.Services;
using UnitTests.Simulator.Mocks;
using Xunit;

namespace UnitTests.Simulator
{
    public class AirplaneSelectorTests
    {
        [Fact]
        public void GettingAirplaneReturnsExpectedAirplane()
        {
            Airplane[] airplanes = new Airplane[] { new Airplane(), new Airplane(), new Airplane() };
            IHubConnectionService hubConnectionService = new HubConnectionServiceMock();
            IWebClientService webClientService = new WebClientMock(airplanes);
            IRandomDataService randomDataService = new RandomDataServiceMock();
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService);

            Airplane airplane = airplaneSelectorService.GetAirplane();

            Assert.Contains(airplane, airplanes);
            
        }

        [Fact]
        public void GetAirplaneFromNullArrayReturnsNull()
        {
            IHubConnectionService hubConnectionService = new HubConnectionServiceMock();
            IWebClientService webClientService = new WebClientMock(null);
            IRandomDataService randomDataService = new RandomDataServiceMock();
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService);

            Airplane airplane = airplaneSelectorService.GetAirplane();

            Assert.Null(airplane);

        }

        [Fact]
        public void GetAirplaneFromEmptyArrayReturnsNull()
        {
            Airplane[] airplanes = new Airplane[] {};
            IWebClientService webClientService = new WebClientMock(airplanes);
            IHubConnectionService hubConnectionService = new HubConnectionServiceMock();
            IRandomDataService randomDataService = new RandomDataServiceMock();
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService);

            Airplane airplane = airplaneSelectorService.GetAirplane();

            Assert.Null(airplane);

        }
    }
}
