using Common.Interfaces;
using Common.Models;
using System;
using System.Threading.Tasks;

namespace BL.Services
{
    public class FlightService : IFlightService
    {
        public Flight Flight { get; }

        public event EventHandler<EventArgs> ReadyToContinue;

        public FlightService(Flight flight)
        {
            if (flight is null) throw new ArgumentNullException(nameof(flight), "A flight cannot be null! This is not Malaysia Airlines!");
            Flight = flight;
        }

        public async Task StartWaitingInStationAsync(int delayInMS)
        {
            if (delayInMS < 0) throw new ArgumentOutOfRangeException(nameof(delayInMS), "Delay time cannot be negative!");
            await Task.Delay(delayInMS);
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
