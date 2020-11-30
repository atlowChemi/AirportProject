using Common.Models;
using Simulator.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Simulator.Mocks
{
    class WebClientMock : IWebClientService
    {
        private readonly ICollection<Airplane> airplanes;

        public WebClientMock(ICollection<Airplane> airplanes = null)
        {
            this.airplanes = airplanes;
        }
        public Task CreateFlight(Flight flight) => Task.Run(() => flight);

        public Task<ICollection<Airplane>> GetAirplanes() => Task.Run(() => airplanes);
    }
}
