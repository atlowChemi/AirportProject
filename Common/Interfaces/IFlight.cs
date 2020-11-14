using Common.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IFlight
    {
        //public Flight Flight { get; set; }
        public Guid Id { get; set; }
        public FlightDirection Direction { get; set; }
        public IAirplane Airplane { get; set; }
        public event EventHandler<EventArgs> ReadyToContinue;
        Task StartWaitingInStationAsync(int delayInMS);
    }
}
