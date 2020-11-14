using System;

namespace Common.Interfaces
{
    public interface IStation : IFlightHandler
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFlight CurrentFlight { get; }
        public bool IsStationAvailable { get; }
        public int WaitingTimeMS { get; }
        public event EventHandler<EventArgs> AvailabiltyChange;
    }
}