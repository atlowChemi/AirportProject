using Common.Models;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Simulator.Mocks
{
    class HubConnectionServiceMock : IHubConnectionService
    {
        private readonly ICollection<Airplane> airplanes;

        public HubConnectionServiceMock(ICollection<Airplane> airplanes = null)
        {
            this.airplanes = airplanes;
        }

        public Task CreateFlight(Flight flight) => Task.Run(() => flight);

        public Task<ICollection<Airplane>> GetAirplanes() => Task.Run(() => airplanes);


        public IDisposable Listen<T>(string methodName, Action<T> handler) => null;
    }
}
