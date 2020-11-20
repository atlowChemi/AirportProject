using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IAirportService
    {
        IEnumerable<Airplane> GetAirplanes();
        Task<Flight> HandleNewFlightArrivedAsync(Flight flight);
    }
}
