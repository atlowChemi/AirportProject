using Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Services
{
    class HubConnectionService : IHubConnectionService
    {
        private readonly HubConnection connection;

        public HubConnectionService()
        {
            connection = new HubConnectionBuilder()
              .WithUrl("http://localhost:63199/flighthub")
              .WithAutomaticReconnect()
              .Build();
            connection.StartAsync();
        }

        public async Task<Flight> CreateFlight(Flight flight)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight), "The flight must not be null!");
            return await InvokeAsync<Flight>("CreateFlight", flight);
        }

        public async Task<ICollection<Airplane>> GetAirplanes()
        {
            return await InvokeAsync<ICollection<Airplane>>("GetAirplanes");
        }
        public IDisposable Listen<T>(string methodName, Action<T> handler)
        {
            return connection.On(methodName, handler);
        }



        public async Task InvokeAsync(string methodName, params object[] data)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("The method name is required!", nameof(methodName));
            await connection.InvokeCoreAsync(methodName, data);
        }
        private async Task<T> InvokeAsync<T>(string methodName, params object[] data)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("The method name is required!", nameof(methodName));
            return await connection.InvokeCoreAsync<T>(methodName, data);
        }
    }
}
