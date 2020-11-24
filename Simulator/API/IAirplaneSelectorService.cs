using Common.Models;

namespace Simulator.API
{
    /// <summary>
    /// Service that returns a random airplane from a set of airplanes.
    /// </summary>
    public interface IAirplaneSelectorService
    {
        /// <summary>
        /// Get a random airplane.
        /// </summary>
        /// <returns>Selected airplane</returns>
        public Airplane GetAirplane();
    }
}
