using BL.Services;
using System;
using Xunit;

namespace UnitTests.BL
{
    public class RandomDataGeneratorTests
    {
        [Fact]
        public void RandomDataGeneratorServiceShouldThrowIfInvalidInput()
        {
            RandomDataGeneratorService randomDataGenerator = new();

            Assert.Throws<ArgumentOutOfRangeException>("max", () => randomDataGenerator.CreateRandomNumber(1, 0));
        }

        [Fact]
        public void RandomDataGeneratorServiceShouldReturnExactIfMinAndMaxEqual()
        {
            RandomDataGeneratorService randomDataGenerator = new();

            int rnd = randomDataGenerator.CreateRandomNumber(1, 1);

            Assert.Equal(1, rnd);
        }

        [Fact]
        public void RandomDataGeneratorServiceShouldReturnInLimits()
        {
            RandomDataGeneratorService randomDataGenerator = new();

            int rnd = randomDataGenerator.CreateRandomNumber(1, 30);

            Assert.True(rnd >= 1 && rnd <= 30);
        }
    }
}
