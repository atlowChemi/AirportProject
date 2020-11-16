﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AirportContext))]
    partial class AirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Common.Models.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirLine")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirLine = "El Al"
                        },
                        new
                        {
                            Id = 2,
                            AirLine = "Lufthansa"
                        },
                        new
                        {
                            Id = 3,
                            AirLine = "United"
                        },
                        new
                        {
                            Id = 4,
                            AirLine = "Frontier"
                        },
                        new
                        {
                            Id = 5,
                            AirLine = "Ryan air"
                        },
                        new
                        {
                            Id = 6,
                            AirLine = "Blue air"
                        },
                        new
                        {
                            Id = 7,
                            AirLine = "Air France"
                        },
                        new
                        {
                            Id = 8,
                            AirLine = "SWISS"
                        },
                        new
                        {
                            Id = 9,
                            AirLine = "Turkish Airlines"
                        });
                });

            modelBuilder.Entity("Common.Models.ControlTower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ControlTowers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"),
                            Name = "TLV"
                        });
                });

            modelBuilder.Entity("Common.Models.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AirplaneId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ControlTowerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("ControlTowerId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62b120ef-33e2-4190-b796-c73427933f0e"),
                            AirplaneId = 1,
                            Direction = 0,
                            From = "JFK",
                            To = "TLV"
                        },
                        new
                        {
                            Id = new Guid("5358068e-0385-4753-90dc-12d0461c04d4"),
                            AirplaneId = 2,
                            Direction = 0,
                            From = "IST",
                            To = "TLV"
                        },
                        new
                        {
                            Id = new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"),
                            AirplaneId = 3,
                            Direction = 0,
                            From = "SAW",
                            To = "TLV"
                        },
                        new
                        {
                            Id = new Guid("dfd8b75c-b624-4a30-8d6e-c77afd746201"),
                            AirplaneId = 4,
                            ControlTowerId = new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"),
                            Direction = 0,
                            From = "STN",
                            To = "TLV"
                        },
                        new
                        {
                            Id = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            AirplaneId = 1,
                            Direction = 1,
                            From = "TLV",
                            To = "ATH"
                        },
                        new
                        {
                            Id = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            AirplaneId = 2,
                            Direction = 1,
                            From = "TLV",
                            To = "LTN"
                        });
                });

            modelBuilder.Entity("Common.Models.FlightHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EnterStationTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LeaveStationTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("StationId");

                    b.ToTable("FlightHistories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("520155bb-706f-4a20-9e65-196350e11ae4"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("62b120ef-33e2-4190-b796-c73427933f0e"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0")
                        },
                        new
                        {
                            Id = new Guid("1b0db67e-aadd-4c9d-813d-04857fcc6207"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("62b120ef-33e2-4190-b796-c73427933f0e"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34")
                        },
                        new
                        {
                            Id = new Guid("068f2bae-b304-4b54-8398-f776b278238a"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("62b120ef-33e2-4190-b796-c73427933f0e"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd")
                        },
                        new
                        {
                            Id = new Guid("163e5855-813a-43c8-8a49-17c2cc045f57"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("62b120ef-33e2-4190-b796-c73427933f0e"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee")
                        },
                        new
                        {
                            Id = new Guid("26aa3702-2d8c-4958-8526-6b12707e59f1"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("5358068e-0385-4753-90dc-12d0461c04d4"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0")
                        },
                        new
                        {
                            Id = new Guid("0b93fe0c-7b08-43fa-af91-3f8ec703d78f"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("5358068e-0385-4753-90dc-12d0461c04d4"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2")
                        },
                        new
                        {
                            Id = new Guid("37cf10bf-e950-4276-9fe1-91ed7db9e2fa"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("5358068e-0385-4753-90dc-12d0461c04d4"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd")
                        },
                        new
                        {
                            Id = new Guid("9e0f0200-621b-4874-9e03-4bdbb7bed9a8"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("5358068e-0385-4753-90dc-12d0461c04d4"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee")
                        },
                        new
                        {
                            Id = new Guid("27642efe-6f3a-4b38-a096-0338d70838e0"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"),
                            StationId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0")
                        },
                        new
                        {
                            Id = new Guid("be5c2155-e808-43f1-ba29-dabcc78062f0"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239")
                        },
                        new
                        {
                            Id = new Guid("9cff5f24-0845-4fa9-9eee-afba08d6f2db"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee")
                        },
                        new
                        {
                            Id = new Guid("b2a12006-9d89-4b20-8d85-a365f748978b"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13")
                        },
                        new
                        {
                            Id = new Guid("4a825c82-5858-4636-bc02-80fdb4d1df30"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad")
                        },
                        new
                        {
                            Id = new Guid("b37f421f-bb6e-478e-a03c-6ec253b5983c"),
                            EnterStationTime = new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36")
                        },
                        new
                        {
                            Id = new Guid("c8ef531a-0641-4dba-a7fa-7098898e64b5"),
                            EnterStationTime = new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239")
                        },
                        new
                        {
                            Id = new Guid("8b65acc7-6e06-4699-b3da-71c3d4cc6eb2"),
                            EnterStationTime = new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee")
                        },
                        new
                        {
                            Id = new Guid("02d8b3ab-9a33-4e6b-a41e-69f7a31e3e95"),
                            EnterStationTime = new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13")
                        },
                        new
                        {
                            Id = new Guid("1b240fc7-82e7-45b3-b3c3-e457e42ad718"),
                            EnterStationTime = new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            LeaveStationTime = new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified),
                            StationId = new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db")
                        },
                        new
                        {
                            Id = new Guid("fd5d2fa2-994a-4b45-b7b2-9293baec9ad1"),
                            EnterStationTime = new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified),
                            FlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            StationId = new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36")
                        });
                });

            modelBuilder.Entity("Common.Models.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrentFlightId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentFlightId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"),
                            CurrentFlightId = new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"),
                            Name = "Land port 1"
                        },
                        new
                        {
                            Id = new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"),
                            Name = "Drop passengers"
                        },
                        new
                        {
                            Id = new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"),
                            Name = "Drop passengers"
                        },
                        new
                        {
                            Id = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"),
                            Name = "Drop lugage"
                        },
                        new
                        {
                            Id = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"),
                            Name = "Refuel"
                        },
                        new
                        {
                            Id = new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"),
                            Name = "Takeoff port 1"
                        },
                        new
                        {
                            Id = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"),
                            Name = "Pick lugage"
                        },
                        new
                        {
                            Id = new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"),
                            Name = "Pick passengers"
                        },
                        new
                        {
                            Id = new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"),
                            Name = "Pick passengers"
                        },
                        new
                        {
                            Id = new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36"),
                            CurrentFlightId = new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"),
                            Name = "Takeoff"
                        });
                });

            modelBuilder.Entity("Common.Models.StationControlTowerRelation", b =>
                {
                    b.Property<Guid>("StationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ControlTowerId")
                        .HasColumnType("TEXT");

                    b.HasKey("StationId", "Direction", "ControlTowerId");

                    b.HasIndex("ControlTowerId");

                    b.HasIndex("StationId")
                        .IsUnique();

                    b.ToTable("StationControlTowerRelation");

                    b.HasData(
                        new
                        {
                            StationId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"),
                            Direction = 0,
                            ControlTowerId = new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191")
                        },
                        new
                        {
                            StationId = new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"),
                            Direction = 1,
                            ControlTowerId = new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191")
                        });
                });

            modelBuilder.Entity("Common.Models.StationRelation", b =>
                {
                    b.Property<Guid>("StationToId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StationFromId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Direction")
                        .HasColumnType("INTEGER");

                    b.HasKey("StationToId", "StationFromId", "Direction");

                    b.HasIndex("StationFromId");

                    b.ToTable("StationRelation");

                    b.HasData(
                        new
                        {
                            StationToId = new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"),
                            StationFromId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"),
                            Direction = 0
                        },
                        new
                        {
                            StationToId = new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"),
                            StationFromId = new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"),
                            Direction = 0
                        },
                        new
                        {
                            StationToId = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"),
                            StationFromId = new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"),
                            Direction = 0
                        },
                        new
                        {
                            StationToId = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"),
                            StationFromId = new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"),
                            Direction = 0
                        },
                        new
                        {
                            StationToId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"),
                            StationFromId = new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"),
                            Direction = 0
                        },
                        new
                        {
                            StationToId = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"),
                            StationFromId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"),
                            Direction = 1
                        },
                        new
                        {
                            StationToId = new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"),
                            StationFromId = new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"),
                            Direction = 1
                        },
                        new
                        {
                            StationToId = new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"),
                            StationFromId = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"),
                            Direction = 1
                        },
                        new
                        {
                            StationToId = new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"),
                            StationFromId = new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"),
                            Direction = 1
                        },
                        new
                        {
                            StationToId = new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36"),
                            StationFromId = new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"),
                            Direction = 1
                        },
                        new
                        {
                            StationToId = new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36"),
                            StationFromId = new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"),
                            Direction = 1
                        });
                });

            modelBuilder.Entity("Common.Models.Flight", b =>
                {
                    b.HasOne("Common.Models.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.ControlTower", "ControlTower")
                        .WithMany("FlightsWaiting")
                        .HasForeignKey("ControlTowerId");

                    b.Navigation("Airplane");

                    b.Navigation("ControlTower");
                });

            modelBuilder.Entity("Common.Models.FlightHistory", b =>
                {
                    b.HasOne("Common.Models.Flight", "Flight")
                        .WithMany("History")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Station", "Station")
                        .WithMany("History")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Common.Models.Station", b =>
                {
                    b.HasOne("Common.Models.Flight", "CurrentFlight")
                        .WithMany()
                        .HasForeignKey("CurrentFlightId");

                    b.Navigation("CurrentFlight");
                });

            modelBuilder.Entity("Common.Models.StationControlTowerRelation", b =>
                {
                    b.HasOne("Common.Models.ControlTower", "ControlTower")
                        .WithMany("FirstStations")
                        .HasForeignKey("ControlTowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Station", "Station")
                        .WithOne("ControlTowerRelation")
                        .HasForeignKey("Common.Models.StationControlTowerRelation", "StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ControlTower");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Common.Models.StationRelation", b =>
                {
                    b.HasOne("Common.Models.Station", "StationFrom")
                        .WithMany("ChildrenStations")
                        .HasForeignKey("StationFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Station", "StationTo")
                        .WithMany("ParentStations")
                        .HasForeignKey("StationToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationFrom");

                    b.Navigation("StationTo");
                });

            modelBuilder.Entity("Common.Models.Airplane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Common.Models.ControlTower", b =>
                {
                    b.Navigation("FirstStations");

                    b.Navigation("FlightsWaiting");
                });

            modelBuilder.Entity("Common.Models.Flight", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("Common.Models.Station", b =>
                {
                    b.Navigation("ChildrenStations");

                    b.Navigation("ControlTowerRelation");

                    b.Navigation("History");

                    b.Navigation("ParentStations");
                });
#pragma warning restore 612, 618
        }
    }
}
