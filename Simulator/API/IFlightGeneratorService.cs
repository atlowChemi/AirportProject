using System;
using System.Threading.Tasks;

namespace Simulator.API
{
    public interface IFlightGeneratorService
    {
        public Task StartGeneratingRandomFlights(Action<string> action);
    }
}
