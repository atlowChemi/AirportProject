using Common.Constants;
using Common.DTO;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    /// <summary>
    /// Handle all airport related requests, adding flights, and retrieving data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService airportService;

        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        /// <summary>
        /// Get all airplanes known to Airport API.
        /// </summary>
        /// <returns>All airplanes known to the system.</returns>
        /// <response code="200">Returns the flights.</response>
        /// <response code="500">If some unknown error happened.</response>
        [HttpGet("airplanes")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AirplaneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<AirplaneDTO>> GetAirplanes()
        {
            try
            {
                return Ok(airportService.GetAirplanes());
            }
            catch (Exception e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = Constants.UNKNOWN_ERROR_MSG,
                    FailureReason = e.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Get paginated history of flights in requested station.
        /// </summary>
        /// <param name="stationId">The ID of the requested station.</param>
        /// <param name="startFrom" example="0">First history item to fetch.</param>
        /// <param name="paginationLimit">The maximal amount of items to return per page.</param>
        /// <returns>Flight history of requested station, limited to the amount requested.</returns>
        /// <response code="200">Returns the station flight histories.</response>
        /// <response code="400">Invalid data sent.</response>
        /// <response code="404">No station with this ID could have been found.</response>
        /// <response code="500">If some unknown error happened.</response>
        [HttpGet("history")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PaginatedDTO<FlightHistory>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status500InternalServerError)]
        public ActionResult<PaginatedDTO<FlightHistoryDTO>> GetStationFlightHistory([Required, FromQuery] Guid stationId, [FromQuery, DefaultValue(0)] int startFrom, [FromQuery, DefaultValue(15)] int paginationLimit)
        {
            if (stationId == Guid.Empty)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "Invalid Id!",
                    FailureReason = "Id must be an actual UUID!"
                };
                return BadRequest(response);
            }
            if (startFrom < 0)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "Invalid start point.",
                    FailureReason = "Can't start retrieving data from negative records!"
                };
                return BadRequest(response);
            }
            if (paginationLimit < 1)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "Invalid pagination limit!",
                    FailureReason = "Can't fetch less than one item per page."
                };
                return BadRequest(response);
            }
            try
            {
                return airportService.GetStationHistory(stationId, startFrom, paginationLimit);
            }
            catch (KeyNotFoundException e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "No station with the given ID was found.",
                    FailureReason = e.Message
                };
                return NotFound(response);
            }
            catch (Exception e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = Constants.UNKNOWN_ERROR_MSG,
                    FailureReason = e.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        /// <summary>
        /// Gets all of the data regarding the control tower with specified name.
        /// </summary>
        /// <param name="name" example="IST">Name of the control tower. 3 upper case chars.</param>
        /// <returns>All the relavant data for the requested control tower.</returns>
        /// <response code="200">Returns the data of the control tower.</response>
        /// <response code="400">If name is empty or invalid.</response>
        /// <response code="404">If now control nower found with given name.</response>
        /// <response code="500">If some unknown error happened.</response>
        [HttpGet("controlTower/{name}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AirportDataDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status500InternalServerError)]
        public ActionResult<AirportDataDTO> GetControllTowerData([RegularExpression(@"^[A-Z]{3}$")] string name)
        {
            if (!ModelState.IsValid)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_SUCCESS,
                    Message = "Invalid name!",
                    FailureReason = $"Name must be 3 upper case characters. {name} is invalid!"
                };
                return BadRequest(response);
            }
            try
            {
                return airportService.GetAirportData(name);
            }
            catch (KeyNotFoundException e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "No control tower with the given name was found!",
                    FailureReason = e.Message
                };
                return NotFound(response);
            }
            catch (Exception e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = "Some unknown error happened, please try again.",
                    FailureReason = e.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Add a new landing / takeoff flight.
        /// </summary>
        /// <param name="flight">Data regarding new flight.</param>
        /// <response code="201">The new flight was generated and is being further handled by server.</response>
        /// <response code="500">If some unknown error happened.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponseDTO), StatusCodes.Status500InternalServerError)]
        public ActionResult<HttpResponseDTO> Post([Required, FromBody] FlightDTO flight)
        {
            Flight dbModel = FlightDTO.ToDBModel(flight);
            try
            {
                airportService.HandleNewFlightArrivedAsync(dbModel);
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_SUCCESS,
                    Message = "Generated flight successfully.",
                };
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception e)
            {
                HttpResponseDTO response = new()
                {
                    ResponseType = Constants.RESPONSE_TYPE_FAILURE,
                    Message = Constants.UNKNOWN_ERROR_MSG,
                    FailureReason = e.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
