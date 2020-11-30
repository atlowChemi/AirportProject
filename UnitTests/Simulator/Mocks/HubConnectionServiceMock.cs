using Simulator.API;
using System;

namespace UnitTests.Simulator.Mocks
{
    class HubConnectionServiceMock : IHubConnectionService
    {
        public IDisposable Listen<T>(string methodName, Action<T> handler) => null;
    }
}
