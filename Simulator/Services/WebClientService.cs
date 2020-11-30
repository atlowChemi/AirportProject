using Common.Models;
using Simulator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Services
{
    public class WebClientService : IWebClientService
    {
        private readonly HttpClient client;

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
            HttpResponseMessage response = await client.GetAsync("api/Airport/airplanes");
            if (response.IsSuccessStatusCode)
            {
                airplanes = await response.Content.ReadAsAsync<ICollection<Airplane>>();
            }
            return airplanes;
        }
    }
}
