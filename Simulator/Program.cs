using Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Simulator.API;
using Simulator.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator
{
    class Program
    {
        private static ManualResetEvent exitEvent;
        static async Task Main(string[] args)
        {

            Console.WriteLine("Welcome to the 1019 Flight simulator!");
            Console.WriteLine("In order to stop proccess click Ctrl + C");

            exitEvent = new ManualResetEvent(false);
            Console.CancelKeyPress += Console_CancelKeyPress;

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRandomDataService, RandomDataService>()
                .AddSingleton<IFlightGeneratorService, FlightGeneratorService>()
                .AddSingleton<IAirplaneSelectorService, AirplaneSelectorService>()
                .AddSingleton<IHubConnectionService, HubConnectionService>()
                .BuildServiceProvider();


            IFlightGeneratorService flightGenerator = serviceProvider.GetService<IFlightGeneratorService>();

            Console.WriteLine("\nEverything is ready, starting to create flights!\n");

            await flightGenerator.StartGeneratingRandomFlights(s => Console.WriteLine(s));
            
            exitEvent.WaitOne();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Exiting simulator.");
            e.Cancel = true;
            exitEvent.Set();
            Environment.Exit(0);
        }
    }
}
