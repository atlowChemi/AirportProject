using Common.Models;
using Microsoft.Extensions.Logging;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Simulator.Services
{
    /// <summary>
    /// Service that handles connections with Web API over a HTTP client.
    /// </summary>
    public class WebClientService : IWebClientService
    {
        /// <summary>
        /// The HTTP client to send request over.
        /// </summary>
        private readonly HttpClient client;
        private readonly ILogger<WebClientService> logger;

        /// <summary>
        /// Generate a new instance 
        /// </summary>
        public WebClientService(ILogger<WebClientService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            client = new HttpClient();
            string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            client.BaseAddress = new Uri(serverUrl);
        }


        public async Task CreateFlight(Flight flight)
        {
            logger.LogInformation("Attempting to send flight to API");
            try
            {
            await client.PostAsJsonAsync("api/Airport", flight);
            logger.LogInformation("Flight sent!");
            }
            catch (HttpRequestException e)
            {
                logger.LogCritical(e, "Flight sending failed!");
            }
        }

        public async Task<ICollection<Airplane>> GetAirplanes()
        {
            ICollection<Airplane> airplanes = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Airport/airplanes");
                if (response.IsSuccessStatusCode)
                {
                    airplanes = await response.Content.ReadAsAsync<ICollection<Airplane>>();
                }
                logger.LogInformation("Airplanes fetched successfully.");
            }
            catch (HttpRequestException e)
            {
                logger.LogCritical(e, "Airplanes fetch failed!");
                airplanes = Array.Empty<Airplane>();
            }
            catch (TaskCanceledException e)
            {
                logger.LogCritical(e, "Airplanes fetch failed!");
                airplanes = Array.Empty<Airplane>();
            }
            return airplanes;
        }
    }
}
