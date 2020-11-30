using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulator.API
{
    /// <summary>
    /// Service that handles connections with Web API over a HTTP client.
    /// </summary>
    public interface IWebClientService
    {
        /// <summary>
        /// Get all airplanes from API.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Airplane"/> fetching.</returns>
        public Task<ICollection<Airplane>> GetAirplanes();
        /// <summary>
        /// Send a new flight to API.
        /// </summary>
        /// <param name="flight">Flight to send.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Flight"/> creating.</returns>
        public Task CreateFlight(Flight flight);
    }
}
