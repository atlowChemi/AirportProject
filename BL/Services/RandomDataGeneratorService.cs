using Common.Interfaces;
using System;

namespace BL.Services
{
    /// <summary>
    /// Service to help generating random data.
    /// </summary>
    public class RandomDataGeneratorService : IRandomDataGeneratorService
    {
        /// <summary>
        /// Random number generator.
        /// </summary>
        private readonly Random random = new Random(DateTime.UtcNow.Millisecond);

        public int CreateRandomNumber(int min, int max)
        {
            if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Maximum range can't be smaller than minimum range!");
            return random.Next(min, max);
        }
    }
}
