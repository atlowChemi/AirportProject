using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Logical wrapper for control towers.
    /// </summary>
    public interface IControlTowerService : IHasNextStations, IGetFlights
    {
        /// <summary>
        /// The control tower the service is handeling.
        /// </summary>
        public ControlTower ControlTower { get; }
    }
}
