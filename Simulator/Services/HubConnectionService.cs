using Microsoft.AspNetCore.SignalR.Client;
using Simulator.API;
using System;

namespace Simulator.Services
{
    /// <summary>
    /// Service that handles connections with SignalR hub.
    /// </summary>
    class HubConnectionService : IHubConnectionService
    {
        /// <summary>
        /// The connection to the hub.
        /// </summary>
        private readonly HubConnection connection;

        /// <summary>
        /// Generate anew instance of the Hub connection service.
        /// </summary>
        public HubConnectionService()
        {
            string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            connection = new HubConnectionBuilder()
              .WithUrl($"{serverUrl}/flighthub")
              .WithAutomaticReconnect()
              .Build();
            connection.StartAsync();
        }

        /// <summary>
        /// Registers a handler that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T">Type of elemets that will return in the listening.</typeparam>
        /// <param name="methodName">The name of the method to register to.</param>
        /// <param name="handler">The handler to handle responses.</param>
        /// <returns></returns>
        public IDisposable Listen<T>(string methodName, Action<T> handler)
        {
            return connection.On(methodName, handler);
        }
    }
}
