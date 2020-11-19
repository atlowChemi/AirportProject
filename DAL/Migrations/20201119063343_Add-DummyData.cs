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
                values: new object[] { 8, "SWISS" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 7, "Air France" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 6, "Blue air" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 9, "Turkish Airlines" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 4, "Frontier" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 3, "United" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 2, "Lufthansa" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "AirLine" },
                values: new object[] { 5, "Ryan air" });

            migrationBuilder.InsertData(
                table: "ControlTowers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("118b248a-047e-46b9-8c58-b7231ab71e53"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("05553c5e-e7db-4119-b3aa-c541282ba671"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0ef08417-c913-4df1-b441-b0873b08533a"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"), 1, null, 0, "JFK", new DateTime(2020, 11, 15, 4, 18, 0, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), 1, null, 1, "TLV", new DateTime(2020, 11, 15, 4, 17, 34, 0, DateTimeKind.Unspecified), "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"), 2, null, 0, "IST", new DateTime(2020, 11, 15, 4, 24, 57, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), 2, null, 1, "TLV", new DateTime(2020, 11, 15, 4, 36, 29, 0, DateTimeKind.Unspecified), "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("3b827feb-70a0-4ca5-a61c-2949413c15bb"), 3, null, 0, "SAW", new DateTime(2020, 11, 15, 4, 26, 18, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("b2db15cf-5276-4a6f-9cc3-649f87a24262"), 4, new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), 0, "STN", new DateTime(2020, 11, 15, 4, 31, 6, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), 1, new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("05553c5e-e7db-4119-b3aa-c541282ba671"), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1"), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0ef08417-c913-4df1-b441-b0873b08533a"), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b"), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd"), new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"), new Guid("118b248a-047e-46b9-8c58-b7231ab71e53") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"), new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("6c54df5c-7f18-4c27-880b-67f9bdaf6d68"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("14ade573-dbf1-4e9e-8868-16dfef39633b"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("15c58836-8a37-4ebc-9316-d3ad5dbe717b"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("90840f1b-811d-435a-93d2-b951730d2ae6"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("a3297c67-addf-4cfd-9d43-c1dc9ec4c336"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e02ea807-e379-470d-8c29-f1b5ee9abd2f"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("eac8249f-7c99-4079-b0bd-8b42f93e07b4"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("118b248a-047e-46b9-8c58-b7231ab71e53") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7e1fce25-2dab-49d5-a77c-9798a132a628"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("05553c5e-e7db-4119-b3aa-c541282ba671") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("5fae48b1-4923-4eef-828a-9da2c6fccd5d"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("b7d04efa-a489-4f7e-a32b-92e0bdaf2520"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("639aaa7f-06a1-46c1-9ffa-7088a7a82adf"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("452c76b8-586b-4e7e-8b28-09dd63823010"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("570bfb0f-12ee-4426-8ffa-ad99162e6122"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("66854bb5-5238-4a42-84bf-4470a4bdd501"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2"), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("e026b844-55f6-4f09-b940-359f18a8d802"), new Guid("3b827feb-70a0-4ca5-a61c-2949413c15bb"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7750d765-ebc7-44f9-9a3f-1ac3585f244b"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("733b66a3-08b7-4cd9-bd79-982a6e959c0f"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"), null, new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("52bdda88-d18e-4774-8739-ec17f67a54bb"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("e026b844-55f6-4f09-b940-359f18a8d802") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7f041b82-5a99-4640-bba9-f42d4e0df6f3"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("e026b844-55f6-4f09-b940-359f18a8d802") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("eccaa4cd-de5e-4184-8498-34befc44633b"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("3b827feb-70a0-4ca5-a61c-2949413c15bb"), null, new Guid("e026b844-55f6-4f09-b940-359f18a8d802") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("118b248a-047e-46b9-8c58-b7231ab71e53"), new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec"), new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802"), new Guid("05553c5e-e7db-4119-b3aa-c541282ba671") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802"), new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1") });
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
                keyValue: new Guid("14ade573-dbf1-4e9e-8868-16dfef39633b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("15c58836-8a37-4ebc-9316-d3ad5dbe717b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("452c76b8-586b-4e7e-8b28-09dd63823010"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("52bdda88-d18e-4774-8739-ec17f67a54bb"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("570bfb0f-12ee-4426-8ffa-ad99162e6122"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("5fae48b1-4923-4eef-828a-9da2c6fccd5d"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("639aaa7f-06a1-46c1-9ffa-7088a7a82adf"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("66854bb5-5238-4a42-84bf-4470a4bdd501"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("6c54df5c-7f18-4c27-880b-67f9bdaf6d68"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("733b66a3-08b7-4cd9-bd79-982a6e959c0f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7750d765-ebc7-44f9-9a3f-1ac3585f244b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7e1fce25-2dab-49d5-a77c-9798a132a628"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7f041b82-5a99-4640-bba9-f42d4e0df6f3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("90840f1b-811d-435a-93d2-b951730d2ae6"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("a3297c67-addf-4cfd-9d43-c1dc9ec4c336"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("b7d04efa-a489-4f7e-a32b-92e0bdaf2520"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e02ea807-e379-470d-8c29-f1b5ee9abd2f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("eac8249f-7c99-4079-b0bd-8b42f93e07b4"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("eccaa4cd-de5e-4184-8498-34befc44633b"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("b2db15cf-5276-4a6f-9cc3-649f87a24262"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), 1, new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"), 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802"), new Guid("05553c5e-e7db-4119-b3aa-c541282ba671") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd"), new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("05553c5e-e7db-4119-b3aa-c541282ba671"), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1"), new Guid("0ef08417-c913-4df1-b441-b0873b08533a") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"), new Guid("118b248a-047e-46b9-8c58-b7231ab71e53") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("e026b844-55f6-4f09-b940-359f18a8d802"), new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"), new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("118b248a-047e-46b9-8c58-b7231ab71e53"), new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec"), new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b"), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0ef08417-c913-4df1-b441-b0873b08533a"), new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("043ef48e-3ab0-43b5-8f55-cbd9e713abd0"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("3a4003d8-7a7a-4ece-98f1-62e29c490414"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("bcab278b-837c-4e0b-b323-60f67f4f76e7"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("c50e024e-dd3e-40c0-bd17-771d1fdab967"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("05553c5e-e7db-4119-b3aa-c541282ba671"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("08ceb74c-d1bb-4007-b70e-af8460680c9b"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0c9f7aec-8d2d-47be-a52e-b023d6d7beb7"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0ef08417-c913-4df1-b441-b0873b08533a"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("118b248a-047e-46b9-8c58-b7231ab71e53"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("16b5988a-74ab-4fb8-a40f-0438fbfb45e1"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("5f7c5c2e-d58d-4ac1-b1e5-b327e83143ec"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e026b844-55f6-4f09-b940-359f18a8d802"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("ea56a6e8-3260-4a5e-a729-c15159de3cb2"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("eecc41cc-dfbf-45cc-8364-f9f9e627cccd"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("3b827feb-70a0-4ca5-a61c-2949413c15bb"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("f0aaebd1-0040-453a-9c24-0916aad35c16"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
