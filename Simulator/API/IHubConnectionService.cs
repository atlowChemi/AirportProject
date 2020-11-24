using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulator.API
{
    /// <summary>
    /// Service that handles connections with SignalR hub.
    /// </summary>
    public interface IHubConnectionService
    {
        /// <summary>
        /// Get all airplanes from Hub.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Airplane"/> fetching.</returns>
        public Task<ICollection<Airplane>> GetAirplanes();
        /// <summary>
        /// Send a new flight to hub.
        /// </summary>
        /// <param name="flight">Flight to send.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Flight"/> creating.</returns>
        public Task CreateFlight(Flight flight);
        /// <summary>
        /// Registers a handler that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="methodName">Hub method to register to.</param>
        /// <param name="handler">The handler that will be raised when the hub method is invoked.</param>
        /// <returns>A subscription that can be disposed to unsubscribe from the hub method.</returns>
        public IDisposable Listen<T>(string methodName, Action<T> handler);
    }
}
