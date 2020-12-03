using Common.Models;
using DAL.DummyData;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Define the control tower model, and set it's name unique.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        public static ModelBuilder SetControlTowerNameToBeUnique(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlTower>()
                .HasIndex(ct => ct.Name)
                .IsUnique();
            return modelBuilder;
        }

        /// <summary>
        /// Define the relation of station and flight.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        public static ModelBuilder DefineStationFlightRelation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>()
                .HasOne(s => s.CurrentFlight)
                .WithOne(f => f.Station)
                .HasForeignKey<Station>(s => s.CurrentFlightId);
            return modelBuilder;
        }

        /// <summary>
        /// Define the control tower ans station relations.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        public static ModelBuilder DefineStationToControlTowerRelation(this ModelBuilder modelBuilder)
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
            return modelBuilder;
        }

        /// <summary>
        /// Define the self relation of the stations.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        public static ModelBuilder DefineStationToStationRelation(this ModelBuilder modelBuilder)
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
            return modelBuilder;
        }

        /// <summary>
        /// Seed to the DB how the intialliztation.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        /// <returns></returns>
        public static ModelBuilder InjectPrePopulatedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(PrePopulateData.Airplanes);
            modelBuilder.Entity<Flight>().HasData(PrePopulateData.Flights);
            modelBuilder.Entity<Station>().HasData(PrePopulateData.Stations);
            modelBuilder.Entity<StationRelation>().HasData(PrePopulateData.StationRelations);
            modelBuilder.Entity<FlightHistory>().HasData(PrePopulateData.FlightHistories);
            modelBuilder.Entity<ControlTower>().HasData(PrePopulateData.ControlTowers);
            modelBuilder.Entity<StationControlTowerRelation>().HasData(PrePopulateData.StationControlTowerRelations);
            return modelBuilder;
        }
    }
}
