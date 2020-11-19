using Common.Models;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IStationTreeBuilderService
    {
        /// <summary>
        /// Indexer to return the controlTowerService by it's name.
        /// </summary>
        /// <param name="name">Name of control tower to get.</param>
        /// <returns>The controlTowerService with a control tower with this name, or null - if no tower found.</returns>
        IControlTowerService this[string name] { get; }

        /// <summary>
        /// Build all Station services, and connect them as defined in the station relations.
        /// </summary>
        /// <param name="controlTowers">All of the control towers to build station tree of.</param>
        /// <param name="stations">Stations related to control towers.</param>
        public void BuildStationsTree(IEnumerable<ControlTower> controlTowers, IEnumerable<Station> stations);
    }
}
