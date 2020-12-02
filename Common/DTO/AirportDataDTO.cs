using System.Collections.Generic;

namespace Common.DTO
{
    /// <summary>
    /// A DTO containing all the DTO's relevant to fire up a Airport (control tower UI).
    /// </summary>
    public class AirportDataDTO
    {
        /// <summary>
        /// All the flights which are currently waiting to land/takeoff.
        /// </summary>
        public IEnumerable<FlightDTO> Flights { get; init; }
        /// <summary>
        /// All the stations connected to the given control tower.
        /// </summary>
        public IEnumerable<StationDTO> Stations { get; init; }
        /// <summary>
        /// The relationships between all the stations.
        /// </summary>
        public IEnumerable<StationRelationDTO> StationRelations { get; init; }
        /// <summary>
        /// The first stations connected to the control tower.
        /// </summary>
        public IEnumerable<StationControlTowerRelationDTO> FirstStations { get; init; }
        /// <summary>
        /// The control tower all this data is related to.
        /// </summary>
        public ControlTowerDTO ControlTower { get; init; }
    }
}
