using Common.Constants;
using Common.Enums;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulator.Services
{
    /// <summary>
    /// Service for random data generating.
    /// </summary>
    public class RandomDataService : IRandomDataService
    {
        /// <summary>
        /// The random generator.
        /// </summary>
        private readonly Random random = new Random(DateTime.UtcNow.Millisecond);
        /// <summary>
        /// The available airports.
        /// </summary>
        private readonly IReadOnlyList<string> airports = Constants.AVAILABLE_AIRPORTS;

        public int RandomNumber(int min, int max)
        {
            if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Maximal number cannot be smaller than the minimal.");
            return random.Next(min, max);
        }

        public async Task RandomDelay(int minSeconds, int maxSeconds)
        {
            if (minSeconds < 0) throw new ArgumentOutOfRangeException(nameof(minSeconds), "Cannot delay for negative time!");
            int timeout = RandomNumber(minSeconds * Constants.ONE_SECOND_IN_MS, maxSeconds * Constants.ONE_SECOND_IN_MS);
            await Task.Delay(timeout);
        }

        public FlightDirection RandomFlightDirection() =>
            Enum.GetValues<FlightDirection>().OrderBy(e => Guid.NewGuid()).FirstOrDefault();

        public string RandomFlightTarget()
        {
            int randomIndex = RandomNumber(0, airports.Count);
            return airports[randomIndex];
        }
    }
}
