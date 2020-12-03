using Common.Models;
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

        /// <summary>
        /// Generate a new instance 
        /// </summary>
        public WebClientService()
        {
            client = new HttpClient();
            string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            client.BaseAddress = new Uri(serverUrl);
        }


        public async Task CreateFlight(Flight flight)
        {
            await client.PostAsJsonAsync("api/Airport", flight);
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
            }
            catch (HttpRequestException e)
            {
                //TODO: log.
                airplanes = Array.Empty<Airplane>();
            }
            catch (TaskCanceledException e)
            {
                //TODO: log.
                airplanes = Array.Empty<Airplane>();
            }
            return airplanes;
        }
    }
}
