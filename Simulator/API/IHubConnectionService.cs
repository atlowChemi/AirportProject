using System;

namespace Simulator.API
{
    /// <summary>
    /// Service that handles connections with SignalR hub.
    /// </summary>
    public interface IHubConnectionService
    {
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
