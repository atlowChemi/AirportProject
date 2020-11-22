using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Logical wrapper for control towers.
    /// </summary>
    public interface IControlTowerService : IHasNextStations
    {
        /// <summary>
        /// The control tower the service is handeling.
        /// </summary>
        public ControlTower ControlTower { get; }
        /// <summary>
        /// Add a flight to the control towers waiting list.
        /// </summary>
        /// <param name="flight">The flight that should land/takeoff.</param>
        void FlightArrived(Flight flight);
    }
}
