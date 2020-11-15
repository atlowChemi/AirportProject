using Common.Enums;
using Simulator.API;
using System;
using System.Threading.Tasks;

namespace Simulator.Services
{
    public class RandomDataService : IRandomDataService
    {
        private readonly Random random = new Random(DateTime.UtcNow.Millisecond);

        public int RandomNumber(int min, int max)
        {
            if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Maximal number cannot be smaller than the minimal.");
            return random.Next(min, max);
        }

        public async Task RandomDelay(int minSeconds, int maxSeconds)
        {
            if (minSeconds < 0) throw new ArgumentOutOfRangeException(nameof(minSeconds), "Cannot delay for negative time!");
            int timeout = RandomNumber(minSeconds * 1000, maxSeconds * 1000);
            await Task.Delay(timeout);
        }

        public FlightDirection RandomFlightDirection() =>
            random.Next() % 2 == 0 ? FlightDirection.Landing : FlightDirection.Takeoff;
    }
}
