using System;

namespace Common.Interfaces
{
    /// <summary>
    /// Generator of random data.
    /// </summary>
    public interface IRandomDataGeneratorService
    {
        /// <summary>
        /// Create a random number.
        /// </summary>
        /// <param name="min">minimal limit for created number.</param>
        /// <param name="max">maximal limit for created number.</param>
        /// <returns>A generated number between given boundaries.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The maximal delay is smaller than miniaml delay.</exception>
        int CreateRandomNumber(int min = 0, int max = int.MaxValue);
    }
}
