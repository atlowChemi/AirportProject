using Simulator.API;
using Simulator.Services;
using System;
using Xunit;

namespace UnitTests.Simulator
{
    public class RandomDataTests
    {
        [Fact]
        public void RandomDelayShouldThrowIfMinIsNegative()
        {
            IRandomDataService randomDataService = new RandomDataService();
            
            Assert.ThrowsAsync<ArgumentOutOfRangeException>("minSeconds", () => randomDataService.RandomDelay(-1, 0));
        }
        [Fact]
        public void RandomDelayShouldThrowIfMaxIsNegative()
        {
            IRandomDataService randomDataService = new RandomDataService();
            
            Assert.ThrowsAsync<ArgumentOutOfRangeException>("maxSeconds",() => randomDataService.RandomDelay(0, -2));
        }
        [Fact]
        public void RandomDelayShouldThrowIfMaxIsSmallerThanMin()
        {
            IRandomDataService randomDataService = new RandomDataService();
            
            Assert.ThrowsAsync<ArgumentOutOfRangeException>("maxSeconds",() => randomDataService.RandomDelay(1, 0));
        }


        [Fact]
        public void RandomNumberShouldThrowIfMaxIsSmallerThanMin()
        {
            IRandomDataService randomDataService = new RandomDataService();

            Assert.Throws<ArgumentOutOfRangeException>("max", () => randomDataService.RandomNumber(max: -1));
        }
        [Fact]
        public void RandomNumberShouldBeWithinLimits()
        {
            IRandomDataService randomDataService = new RandomDataService();

            int min = 0;
            int max = 5;
            int randomNumber = randomDataService.RandomNumber(min, max);

            Assert.InRange(randomNumber, min, max);
        }
        [Fact]
        public void RandomNumberShouldEqualIfMinAndMaxAreSame()
        {
            IRandomDataService randomDataService = new RandomDataService();

            int val = 7;
            int randomNumber = randomDataService.RandomNumber(val, val);

            Assert.Equal(val, randomNumber);
        }
    }
}
