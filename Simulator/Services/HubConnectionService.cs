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

        public async Task CreateFlight(Flight flight)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight), "The flight must not be null!");
            await connection.InvokeAsync("FlightArrival", flight);
        }

        public async Task<ICollection<Airplane>> GetAirplanes()
        {
            return await connection.InvokeAsync<ICollection<Airplane>>("GetAirplanes");
        }
        public IDisposable Listen<T>(string methodName, Action<T> handler)
        {
            return connection.On(methodName, handler);
        }
    }
}
