using Common.Interfaces;
using System;

namespace BL.Services
{
    public class RandomDataGeneratorService : IRandomDataGeneratorService
    {
        private readonly Random random = new Random(DateTime.UtcNow.Millisecond);

        public int CreateRandomNumber(int min, int max)
        {
            if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Maximum range can't be smaller than minimum range!");
            return random.Next(min, max);
        }
    }
}
