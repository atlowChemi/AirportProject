using Microsoft.AspNetCore.SignalR.Client;
using Simulator.API;
using System;

namespace Simulator.Services
{
    class HubConnectionService : IHubConnectionService
    {
        private readonly HubConnection connection;

        public HubConnectionService()
        {
            string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            connection = new HubConnectionBuilder()
              .WithUrl($"{serverUrl}/flighthub")
              .WithAutomaticReconnect()
              .Build();
            connection.StartAsync();
        }

        public IDisposable Listen<T>(string methodName, Action<T> handler)
        {
            return connection.On(methodName, handler);
        }
    }
}
