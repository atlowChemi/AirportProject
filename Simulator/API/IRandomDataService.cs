using Common.Enums;
using System.Threading.Tasks;

namespace Simulator.API
{
    public interface IRandomDataService
    {
        public Task RandomDelay(int minSeconds = 1, int maxSeconds = 5);
        public FlightDirection RandomFlightDirection();
        public int RandomNumber(int min = 0, int max = int.MaxValue);
    }
}
