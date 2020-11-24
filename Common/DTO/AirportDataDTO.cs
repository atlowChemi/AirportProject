using Common.Models;
using System.Collections.Generic;

namespace Common.DTO
{
    public class AirportDataDTO
    {
        public IEnumerable<Flight> Flights { get; init; }
        public ControlTower ControlTower { get; init; }
    }
}
