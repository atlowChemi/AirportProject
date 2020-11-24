using System;
using System.Threading.Tasks;

namespace Simulator.API
{
    /// <summary>
    /// Service that generates random flights.
    /// </summary>
    public interface IFlightGeneratorService
    {
        /// <summary>
        /// Generate random flights
        /// </summary>
        /// <param name="action">handle the data of inputed flight.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Common.Models.Flight"/> generating.</returns>
        public Task StartGeneratingRandomFlights(Action<string> action);
    }
}
