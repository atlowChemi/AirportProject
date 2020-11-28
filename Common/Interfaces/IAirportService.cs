using Common.DTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    /// <summary>
    /// Service to handle the whole orchestra of the airport.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Get all <see cref="Airplane">airplanes</see> available.
        /// </summary>
        /// <returns>All airplanes in the system.</returns>
        IEnumerable<AirplaneDTO> GetAirplanes();
        /// <summary>
        /// Handle the situation of a new <see cref="Flight"/> arriving the airport.
        /// </summary>
        /// <param name="flight">The flight that has arrived.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous <see cref="Flight"/> handeling</returns>
        Task HandleNewFlightArrivedAsync(Flight flight);
        /// <summary>
        /// Get all <see cref="Flight">Flights</see> which did not yet start the land/takeoff procedure.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Flight}"/> with waiting flights.</returns>
        IEnumerable<Flight> GetWaitingFlights();
        /// <summary>
        /// Get the relavent data of a <see cref="ControlTower"/> with the a given name.
        /// </summary>
        /// <param name="name">The name of the control tower</param>
        /// <returns>The data of the control tower.</returns>
        AirportDataDTO GetAirportData(string name);
        /// <summary>
        /// Get the <see cref="FlightHistory"/> of the a <see cref="Station"/> with a given id.
        /// </summary>
        /// <param name="stationId">Id of requested station.</param>
        /// <param name="startFrom">Row of history to start from. (pagination)</param>
        /// <returns>The flight history of the station.</returns>
        PaginatedDTO<FlightHistoryDTO> GetStationHistory(Guid stationId, int startFrom = 0, int paginationLimit = 15);
    }
}
