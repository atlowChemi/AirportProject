using System;
using System.IO;
using BL.Services;
using Common.Interfaces;
using Common.Repositories;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Server.Hubs;
using Server.HubServices;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("SignalRCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:8080", "http://localhost:56673")
                    .WithMethods("GET", "POST").AllowAnyHeader().AllowCredentials();
            }));
            services.AddDbContext<AirportContext>(opt =>
            {
                string relativeDataSource = Path.Combine(Environment.CurrentDirectory, @"..\", "DAL", "airport.db");
                string dataSource = Path.GetFullPath(relativeDataSource);
                opt
                    .UseSqlite($"Data Source={dataSource}")
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(warn => warn.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
            });

            services.AddSingleton<INotifier, FlightHubNotifier>();
            services.AddSingleton<IAirportDBService, AirportDBService>();
            services.AddSingleton<IAirportEventsService, AirportEventsService>();
            services.AddSingleton<IRandomDataGeneratorService, RandomDataGeneratorService>();
            services.AddSingleton<IStationTreeBuilderService, StationTreeBuilderService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAirportService, AirportService>();
            services.AddSignalR().AddNewtonsoftJsonProtocol(o => o.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("SignalRCorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<FlightHub>("/flighthub");
            });
        }
    }
}
