using Common.Enums;
using System;

namespace Common.Interfaces
{
    public interface IAirplane
    {
        public int Id { get; set; }
        public AirplaneDirection Direction { get; set; }
        public event EventHandler ReadyToContinue;
        void StartWaitingInStation();
    }
}