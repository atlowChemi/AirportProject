using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulator.API
{
    public interface IHubConnectionService
    {

        //public Task InvokeAsync(string methodName, params object[] data);
        public Task<ICollection<Airplane>> GetAirplanes();
        public Task<Flight> CreateFlight(Flight flight);
        public IDisposable Listen<T>(string methodName, Action<T> handler);
    }
}
