using Common.Models;
using System;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IFlightService
    {
        public Flight Flight { get; }
        public event EventHandler<EventArgs> ReadyToContinue;
        Task StartWaitingInStationAsync(int delayInMS);
    }
}
