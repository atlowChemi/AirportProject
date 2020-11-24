using System.Collections.Generic;

namespace Common.DTO
{
    public class AirportDataDTO
    {
        public IEnumerable<FlightDTO> Flights { get; init; }
        public IEnumerable<StationDTO> Stations { get; init; }
        public IEnumerable<StationRelationDTO> StationRelations { get; init; }
        public IEnumerable<StationControlTowerRelationDTO> FirstStations { get; init; }

        public ControlTowerDTO ControlTower { get; init; }
    }
}
