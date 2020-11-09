using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IAirplaneHandler
    {
        public string Name { get; set; }
        ICollection<IStation> TakeoffStations { get; }
        ICollection<IStation> LandingStations { get; }
        void PlaneArrived(IAirplane airplane);
    }
}
