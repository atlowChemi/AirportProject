using Common.Models;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IStationTreeBuilderService
    {
        /// <summary>
        /// Build the Station services, and connect them as defined in the station relations.
        /// </summary>
        /// <param name="controlTowerName">Name of control tower to build station tree for.</param>
        /// <returns>The control tower service that will manage the usage of these stations.</returns>
        public Task<IControlTowerService> BuildStationsTreeAsync(string controlTowerName);
    }
}
