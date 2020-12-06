using Common.Models;
using Microsoft.Extensions.Logging;
using Simulator.API;
using Simulator.Services;
using UnitTests.Mocks;
using UnitTests.Simulator.Mocks;
using Xunit;

namespace UnitTests.Simulator
{
    public class AirplaneSelectorTests
    {
        ILogger<IAirplaneSelectorService> logger = new LoggerMock<IAirplaneSelectorService>();
        [Fact]
        public void GettingAirplaneReturnsExpectedAirplane()
        {
            Airplane[] airplanes = new Airplane[] { new Airplane(), new Airplane(), new Airplane() };
            IHubConnectionService hubConnectionService = new HubConnectionServiceMock();
            IWebClientService webClientService = new WebClientMock(airplanes);
            IRandomDataService randomDataService = new RandomDataServiceMock();
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService, logger);

            Airplane airplane = airplaneSelectorService.GetAirplane();

            Assert.Contains(airplane, airplanes);
            
        }

        [Fact]
        public void GetAirplaneFromNullArrayReturnsNull()
        {
            IHubConnectionService hubConnectionService = new HubConnectionServiceMock();
            IWebClientService webClientService = new WebClientMock(null);
            IRandomDataService randomDataService = new RandomDataServiceMock();
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService, logger);

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
            IAirplaneSelectorService airplaneSelectorService = new AirplaneSelectorService(webClientService, hubConnectionService, randomDataService, logger);

            Airplane airplane = airplaneSelectorService.GetAirplane();

            Assert.Null(airplane);

        }
    }
}
