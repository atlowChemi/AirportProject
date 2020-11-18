using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IControlTowerService : IHasNextStations
    {
        //public ControlTower ControlTower { get; set; }
        Task<Flight> FlightArrived(Flight flight);
    }
}
