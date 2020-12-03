using Common.Models;
using DAL.DummyData;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    /// The DbContext handeling the airport related tables.
    /// </summary>
    public class AirportContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportContext"/> class using the specified options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        /// <summary>
        /// The set of all stations.
        /// </summary>
        public virtual DbSet<Station> Stations { get; set; }
        /// <summary>
        /// The set of all airplanes.
        /// </summary>
        public virtual DbSet<Airplane> Airplanes { get; set; }
        /// <summary>
        /// The set of all flights.
        /// </summary>
        public virtual DbSet<Flight> Flights { get; set; }
        /// <summary>
        /// The set of all flight histories.
        /// </summary>
        public virtual DbSet<FlightHistory> FlightHistories { get; set; }
        /// <summary>
        /// The set of all control towers.
        /// </summary>
        public virtual DbSet<ControlTower> ControlTowers { get; set; }
        /// <summary>
        /// The set of all station relations.
        /// </summary>
        public virtual DbSet<StationRelation> StationRelations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetControlTowerNameToBeUnique()
                .DefineStationFlightRelation()
                .DefineStationToStationRelation()
                .DefineStationToControlTowerRelation()
                .InjectPrePopulatedData();
        }
    }
}
