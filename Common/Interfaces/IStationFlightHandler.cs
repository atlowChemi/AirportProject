using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Element that can handle Incoming flights.
    /// </summary>
    public interface IStationFlightHandler : IGetFlights, IFlightChanger
    {
        /// <summary>
        /// The station the service is handeling.
        /// </summary>
        public Station Station { get; }
        /// <summary>
        /// Is handler is available currently.
        /// </summary>
        public bool IsHandlerAvailable { get; }
    }
}
