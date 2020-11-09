using System;

namespace Common.Interfaces
{
    public interface IStation : IAirplaneHandler
    {
        public int Id { get; set; }
        public IAirplane Airplane { get; }
        public bool IsStationAvailable { get; }
        public event EventHandler AvailabiltyChange;
    }
}