using Common.Enums;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Simulator.Mocks
{
    public class RandomDataServiceMock : IRandomDataService
    {
        private readonly FlightDirection direction;
        private readonly int presetRandomResult;

        public RandomDataServiceMock(FlightDirection direction = FlightDirection.Landing, int presetRandomResult = 0)
        {
            this.direction = direction;
            this.presetRandomResult = presetRandomResult;
        }
        public async Task RandomDelay(int minSeconds = 1, int maxSeconds = 5)
        {
            await Task.Delay(0);
        }

        public FlightDirection RandomFlightDirection() => direction;

        public int RandomNumber(int min = 0, int max = int.MaxValue) => presetRandomResult;
    }
}
