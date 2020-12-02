using Common.Enums;
using System;
using System.Threading.Tasks;

namespace Simulator.API
{
    /// <summary>
    /// Service for random data generating.
    /// </summary>
    public interface IRandomDataService
    {
        /// <summary>
        /// Create and wait a random amount of time.
        /// </summary>
        /// <param name="minSeconds">Minimal waiting time in seconds.</param>
        /// <param name="maxSeconds">Maximal waiting time in seconds.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delay.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Tha max delay is larger the small one.</exception>
        public Task RandomDelay(int minSeconds = 1, int maxSeconds = 5);
        /// <summary>
        /// Select a random flight direction.
        /// </summary>
        /// <returns>Randomly selected flight direction.</returns>
        public FlightDirection RandomFlightDirection();
        /// <summary>
        /// Generate a random flight target.
        /// </summary>
        /// <returns>Generated flight target.</returns>
        public string RandomFlightTarget();
        /// <summary>
        /// Generate a random number.
        /// </summary>
        /// <param name="min">Minimal range for created number.</param>
        /// <param name="max">Maximal range for created number.</param>
        /// <returns>Generated number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Maximal number cannot be smaller than the minimal.</exception>
        public int RandomNumber(int min = 0, int max = int.MaxValue);
    }
}
