using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 1, "El Al" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 2, "Lufthansa" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 3, "United" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 4, "Frontier" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 5, "Ryan air" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 6, "Blue air" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 7, "Air France" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 8, "SWISS" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 9, "Turkish Airlines" });

            migrationBuilder.InsertData(
                table: "ControlTowers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"), 1, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, "JFK", new DateTime(2020, 11, 15, 4, 18, 0, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"), 2, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, "IST", new DateTime(2020, 11, 15, 4, 24, 57, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("727c9721-ed85-403e-995a-93c38ef1cf92"), 3, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, "SAW", new DateTime(2020, 11, 15, 4, 26, 18, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("6fe84c76-62da-4d64-a20f-f14acd3e3a0a"), 4, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, "STN", new DateTime(2020, 11, 15, 4, 31, 6, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), 1, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 1, "TLV", new DateTime(2020, 11, 15, 4, 17, 34, 0, DateTimeKind.Unspecified), null, "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), 2, new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 1, "TLV", new DateTime(2020, 11, 15, 4, 36, 29, 0, DateTimeKind.Unspecified), null, "LTN" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("3289ed56-24e7-4468-b073-a55ac47a838a"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("68c84573-0f39-499e-9f79-5b5acff30619"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("610d10c9-1075-4ed8-9343-8be8905506bf"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("f21a6c05-2714-4f14-a464-35250d85ee06"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1dc67b96-6faa-41d4-ba88-1f1918d5c9ab"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1d3974fd-9583-4333-a49c-9b0602257db1"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("610d10c9-1075-4ed8-9343-8be8905506bf") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3ccf15e9-6531-4066-b26a-7646c1da89d8"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("610d10c9-1075-4ed8-9343-8be8905506bf") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("4ddce015-cd1a-4a55-a614-18672dfbd25f"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("25df3a17-cdc8-4538-8c11-7b73eba2702b"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("f21a6c05-2714-4f14-a464-35250d85ee06") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d3927a67-af8c-46fc-965d-902cfe3cae44"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("670aa5de-114b-40fc-9a80-86998704999b"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d11c72bd-361f-4896-9ee7-46a1a83f6c48"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("387c72bc-08f8-41fb-a3fc-9d0b9a1387d2"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("0391d79f-e050-41a8-b3f8-7093369ed29b"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("6f9914bf-6290-4874-9566-d8ad4437c0f0"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("014c7088-e2b1-4130-97cc-6575cf1db7da"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c1980f62-7072-4607-b0e6-08cb3f356b87"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("27992b63-3741-4760-95b6-73f15fc62f88"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 1, new Guid("610d10c9-1075-4ed8-9343-8be8905506bf") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"), new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("68c84573-0f39-499e-9f79-5b5acff30619"), new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"), new Guid("f21a6c05-2714-4f14-a464-35250d85ee06") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("3289ed56-24e7-4468-b073-a55ac47a838a"), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4"), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef"), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("610d10c9-1075-4ed8-9343-8be8905506bf"), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"), new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), new Guid("727c9721-ed85-403e-995a-93c38ef1cf92"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("71b81dd2-761f-49df-bc60-7988cea045f1"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d87e1236-f062-4d0f-968a-bbde7e501921"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7623e60a-7bc6-41a1-b142-576eba871d8b"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("727c9721-ed85-403e-995a-93c38ef1cf92"), null, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("991336f4-5125-4b63-9ec3-3a28ebcf0433"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d90921bc-86b0-4d77-9d6a-e74c779b4d4f"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"), null, new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"), new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"), new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0"), new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("f21a6c05-2714-4f14-a464-35250d85ee06"), new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("014c7088-e2b1-4130-97cc-6575cf1db7da"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("0391d79f-e050-41a8-b3f8-7093369ed29b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1d3974fd-9583-4333-a49c-9b0602257db1"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1dc67b96-6faa-41d4-ba88-1f1918d5c9ab"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("25df3a17-cdc8-4538-8c11-7b73eba2702b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("27992b63-3741-4760-95b6-73f15fc62f88"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("387c72bc-08f8-41fb-a3fc-9d0b9a1387d2"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3ccf15e9-6531-4066-b26a-7646c1da89d8"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("4ddce015-cd1a-4a55-a614-18672dfbd25f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("670aa5de-114b-40fc-9a80-86998704999b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("6f9914bf-6290-4874-9566-d8ad4437c0f0"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("71b81dd2-761f-49df-bc60-7988cea045f1"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7623e60a-7bc6-41a1-b142-576eba871d8b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("991336f4-5125-4b63-9ec3-3a28ebcf0433"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c1980f62-7072-4607-b0e6-08cb3f356b87"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d11c72bd-361f-4896-9ee7-46a1a83f6c48"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d3927a67-af8c-46fc-965d-902cfe3cae44"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d87e1236-f062-4d0f-968a-bbde7e501921"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d90921bc-86b0-4d77-9d6a-e74c779b4d4f"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("6fe84c76-62da-4d64-a20f-f14acd3e3a0a"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 1, new Guid("610d10c9-1075-4ed8-9343-8be8905506bf") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"), 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"), new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef"), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4"), new Guid("3289ed56-24e7-4468-b073-a55ac47a838a") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0"), new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("f21a6c05-2714-4f14-a464-35250d85ee06"), new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"), new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("3289ed56-24e7-4468-b073-a55ac47a838a"), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("610d10c9-1075-4ed8-9343-8be8905506bf"), new Guid("68c84573-0f39-499e-9f79-5b5acff30619") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"), new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("68c84573-0f39-499e-9f79-5b5acff30619"), new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"), new Guid("f21a6c05-2714-4f14-a464-35250d85ee06") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("52160cb7-23f1-4b49-9173-44ff0d50e0cc"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("82a910bc-a761-40b4-b76d-a86962b95f76"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("df8444a6-03e2-4f40-a7cb-c3543eba3ca3"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("1ab04ed3-9217-4580-bb79-88e88219f3ef"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("3289ed56-24e7-4468-b073-a55ac47a838a"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("3eebbec4-88eb-46b2-bb43-9234af22adec"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("4c37c5ea-ef60-48f7-8aa4-f257e044bfe4"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("610d10c9-1075-4ed8-9343-8be8905506bf"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("68c84573-0f39-499e-9f79-5b5acff30619"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("806e0e23-ae31-4aa1-9736-1a0c279fe84d"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("9d1f0ed8-9c4c-43c5-9975-ae5af2a989e0"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e855dd46-109e-4fc2-afbc-d25092bf7b73"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("f21a6c05-2714-4f14-a464-35250d85ee06"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("49908bd7-a72a-4aff-a1f7-0b889f747a04"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("727c9721-ed85-403e-995a-93c38ef1cf92"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("0b213d74-6872-4f5b-9e9e-82832cb77334"));
        }
    }
}
