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
        int CreateRandomNumber(int min = 0, int max = int.MaxValue);
    }
}
