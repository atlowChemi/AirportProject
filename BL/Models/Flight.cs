using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Flight : IFlight
    {
        public Guid Id { get; set; }
        public FlightDirection Direction { get; set; }
        public IAirplane Airplane { get; set; }

        public event EventHandler<EventArgs> ReadyToContinue;

        public async void StartWaitingInStation(int delayInMS)
        {
            await Task.Delay(delayInMS);
            ReadyToContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
