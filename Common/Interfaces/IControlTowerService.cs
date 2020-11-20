using Common.Models;

namespace Common.Interfaces
{
    public interface IControlTowerService : IHasNextStations
    {
        public ControlTower ControlTower { get; }
        void FlightArrived(Flight flight);
    }
}
