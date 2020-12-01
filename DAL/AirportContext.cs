using Common.Models;
using DAL.DummyData;
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
            SetControlTowerNameToBeUnique(modelBuilder);
            DefineStationFlightRelation(modelBuilder);
            DefineStationToStationRelation(modelBuilder);
            DefineStationToControlTowerRelation(modelBuilder);
            InjectPrePopulatedData(modelBuilder);
        }


        /// <summary>
        /// Defince the control tower model, and set it's name unique.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        private void SetControlTowerNameToBeUnique(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlTower>()
                .HasIndex(ct => ct.Name)
                .IsUnique();
        }
        /// <summary>
        /// Define the relation of station and flight.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        private void DefineStationFlightRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>()
                .HasOne(s => s.CurrentFlight)
                .WithOne(f => f.Station)
                .HasForeignKey<Station>(s => s.CurrentFlightId);
        }
        /// <summary>
        /// Define the control tower ans station relations.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        private void DefineStationToControlTowerRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationControlTowerRelation>(entity =>
            {
                entity.HasKey(sctr => new { sctr.StationToId, sctr.Direction, sctr.ControlTowerId });
                entity
                    .HasOne(sctr => sctr.Station)
                    .WithOne(s => s.ControlTowerRelation)
                    .HasForeignKey<StationControlTowerRelation>(sctr => sctr.StationToId);
                entity
                    .HasOne(sctr => sctr.ControlTower)
                    .WithMany(ct => ct.FirstStations)
                    .HasForeignKey(sctr => sctr.ControlTowerId);
            });
        }
        /// <summary>
        /// Define the self relation of the stations.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        private void DefineStationToStationRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationRelation>(entity =>
            {
                entity.HasKey(sr => new { sr.StationToId, sr.StationFromId, sr.Direction });
                entity
                    .HasOne(sr => sr.StationFrom)
                    .WithMany(s => s.ChildrenStations)
                    .HasForeignKey(sr => sr.StationFromId);
                entity
                    .HasOne(sr => sr.StationTo)
                    .WithMany(s => s.ParentStations)
                    .HasForeignKey(sr => sr.StationToId);
            });
        }
        /// <summary>
        /// Inject (seed) data into the DB.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        private void InjectPrePopulatedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(PrePopulateData.Airplanes);
            modelBuilder.Entity<Flight>().HasData(PrePopulateData.Flights);
            modelBuilder.Entity<Station>().HasData(PrePopulateData.Stations);
            modelBuilder.Entity<StationRelation>().HasData(PrePopulateData.StationRelations);
            modelBuilder.Entity<FlightHistory>().HasData(PrePopulateData.FlightHistories);
            modelBuilder.Entity<ControlTower>().HasData(PrePopulateData.ControlTowers);
            modelBuilder.Entity<StationControlTowerRelation>().HasData(PrePopulateData.StationControlTowerRelations);
        }
    }
}
