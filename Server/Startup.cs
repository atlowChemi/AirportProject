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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Server.Hubs;

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
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                    .WithMethods("GET", "POST").AllowAnyHeader().AllowCredentials();
            }));
            services.AddDbContext<AirportContext>(opt =>
            {
                string relativeDataSource = Path.Combine(Environment.CurrentDirectory, @"..\", "DAL", "airport.db");
                string dataSource = Path.GetFullPath(relativeDataSource);
                opt.UseSqlite($"Data Source={dataSource}");
            });

            services.AddSingleton<IRandomDataGeneratorService, RandomDataGeneratorService>();
            services.AddSingleton<IStationTreeBuilderService, StationTreeBuilderService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAirportService, AirportService>();
            services.AddSignalR()
                #if DEBUG
                .AddHubOptions<FlightHub>(o => o.ClientTimeoutInterval = new TimeSpan(5, 5, 5))
                #endif
                .AddNewtonsoftJsonProtocol(o => o.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<FlightHub>("/flighthub");
            });
        }
    }
}
