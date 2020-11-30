using Common.DTO;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService airportService;

        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(AirportDataDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<AirportDataDTO> GetControllTowerData(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Name not existing");
            try
            {
                return airportService.GetAirportData(name);
                throw new AggregateException();
            } catch (KeyNotFoundException)
            {
                return NotFound("No control tower with the given name was found!");
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some unknown error happened, please try again");
            }
        }

        [HttpGet("airplanes")]
        [ProducesResponseType(typeof(IEnumerable<AirplaneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<AirplaneDTO>> GetAirplanes()
        {
            try
            {
                return Ok(airportService.GetAirplanes());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some unknown error happened, please try again");
            }
        }

        [HttpGet("history")]
        [ProducesResponseType(typeof(PaginatedDTO<FlightHistory>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<PaginatedDTO<FlightHistoryDTO>> GetStationFlightHistory(Guid stationId, int startFrom = 0, int paginationLimit = 15)
        {
            if (stationId == Guid.Empty) return BadRequest("Can't search with no ID.");
            if (startFrom < 0) return BadRequest("Can't start from negative records.");
            if (paginationLimit < 1) return BadRequest("Can't fetch less than one item per page.");
            try
            {
                return airportService.GetStationHistory(stationId, startFrom, paginationLimit);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("No station with the given ID was found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some unknown error happened, please try again");
            }
        }

        // POST api/<AirportController>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public ActionResult Post([FromBody] FlightDTO flight)
        {
            Flight dbModel = FlightDTO.ToDBModel(flight);
            airportService.HandleNewFlightArrivedAsync(dbModel);
            return StatusCode(StatusCodes.Status201Created, "Generated flight successfully.");
        }
    }
}
