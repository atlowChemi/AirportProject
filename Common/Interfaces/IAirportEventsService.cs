using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void AddStationsToListenTo(IEnumerable<IStationService> stationServices);
    }
}
