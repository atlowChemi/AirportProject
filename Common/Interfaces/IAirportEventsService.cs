using System.Collections.Generic;

namespace Common.Interfaces
{
    /// <summary>
    /// Service that registers to all relevant events and handels them.
    /// </summary>
    public interface IAirportEventsService
    {
        /// <summary>
        /// Add stations which need to be registered to.
        /// </summary>
        /// <param name="stationServices">The station to register to.</param>
        void AddStationsToListenTo(IEnumerable<IFlightChanger> stationServices);
    }
}
