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
                values: new object[] { new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"), 1, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, "JFK", new DateTime(2020, 11, 15, 4, 18, 0, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"), 2, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, "IST", new DateTime(2020, 11, 15, 4, 24, 57, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("ca2b41fc-d7d1-4305-9e35-a435204023f0"), 3, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, "SAW", new DateTime(2020, 11, 15, 4, 26, 18, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("1164532a-8f88-4be1-ac00-c6a3c5978641"), 4, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, "STN", new DateTime(2020, 11, 15, 4, 31, 6, 0, DateTimeKind.Unspecified), null, "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), 1, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 1, "TLV", new DateTime(2020, 11, 15, 4, 17, 34, 0, DateTimeKind.Unspecified), null, "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "StationId", "To" },
                values: new object[] { new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), 2, new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 1, "TLV", new DateTime(2020, 11, 15, 4, 36, 29, 0, DateTimeKind.Unspecified), null, "LTN" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("007de4a2-165c-44d4-857a-009918751144"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("05451801-c66c-4646-8091-b954e49ed776"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("1241505e-4432-4724-b393-f600d3e3b80b"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("2c1bd411-b916-4411-95da-f0a6e09894c3"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("08765da2-ceb2-435a-ab84-e7b78d6e4aaa"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("5d957e59-3015-427b-8729-450b8e255204"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("f83b88fb-6adb-447b-9b64-ce01bc4a4e59"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("1241505e-4432-4724-b393-f600d3e3b80b") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ebb8a08e-bfab-46e0-bcd1-5b9348d56711"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("4e8e6874-d87c-4524-bc55-673ccd264100"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("609c255c-5a93-471d-84b7-3f9a9852d09b"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("91671abe-9d3e-40f7-b0b6-49fa93d874d9"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("196f67ae-026d-4127-b54f-2413e1faddc5"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c0c2e588-d15d-4412-a296-0ca3c0efe67c"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7ee506a7-0544-4ffe-9b8a-fcfc23ad9cdb"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("defe4cd0-9d5b-4252-808d-c6422b897c1f"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c847b9e3-777a-4b45-b437-f79858bfb4b7"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("92050d6f-d33c-4001-801c-48225c613dd7"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("1241505e-4432-4724-b393-f600d3e3b80b") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 1, new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("1241505e-4432-4724-b393-f600d3e3b80b"), new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("05451801-c66c-4646-8091-b954e49ed776"), new Guid("1241505e-4432-4724-b393-f600d3e3b80b") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("1241505e-4432-4724-b393-f600d3e3b80b"), new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("007de4a2-165c-44d4-857a-009918751144"), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf"), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c"), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d"), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"), new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), new Guid("ca2b41fc-d7d1-4305-9e35-a435204023f0"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1728005f-07a2-4d4c-bc22-dc28a1d94b7b"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("db82ddb8-b306-4563-8441-506e06cb4bda"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("05fd8115-29bb-4a90-a9c6-316e7181c370"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("ca2b41fc-d7d1-4305-9e35-a435204023f0"), null, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("26af5728-d6fe-4660-b1ae-a4e036e83c14"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("84417ef8-9f4b-4ae7-a245-6bc51a315be5"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"), null, new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"), new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"), new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280"), new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });

            migrationBuilder.InsertData(
                table: "StationRelations",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e"), new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });
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
                keyValue: new Guid("05fd8115-29bb-4a90-a9c6-316e7181c370"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("08765da2-ceb2-435a-ab84-e7b78d6e4aaa"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1728005f-07a2-4d4c-bc22-dc28a1d94b7b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("196f67ae-026d-4127-b54f-2413e1faddc5"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("26af5728-d6fe-4660-b1ae-a4e036e83c14"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("2c1bd411-b916-4411-95da-f0a6e09894c3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("4e8e6874-d87c-4524-bc55-673ccd264100"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("5d957e59-3015-427b-8729-450b8e255204"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("609c255c-5a93-471d-84b7-3f9a9852d09b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7ee506a7-0544-4ffe-9b8a-fcfc23ad9cdb"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("84417ef8-9f4b-4ae7-a245-6bc51a315be5"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("91671abe-9d3e-40f7-b0b6-49fa93d874d9"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("92050d6f-d33c-4001-801c-48225c613dd7"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c0c2e588-d15d-4412-a296-0ca3c0efe67c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c847b9e3-777a-4b45-b437-f79858bfb4b7"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("db82ddb8-b306-4563-8441-506e06cb4bda"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("defe4cd0-9d5b-4252-808d-c6422b897c1f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ebb8a08e-bfab-46e0-bcd1-5b9348d56711"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("f83b88fb-6adb-447b-9b64-ce01bc4a4e59"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("1164532a-8f88-4be1-ac00-c6a3c5978641"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"), 1, new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c"), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf"), new Guid("007de4a2-165c-44d4-857a-009918751144") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("007de4a2-165c-44d4-857a-009918751144"), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d"), new Guid("05451801-c66c-4646-8091-b954e49ed776") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("05451801-c66c-4646-8091-b954e49ed776"), new Guid("1241505e-4432-4724-b393-f600d3e3b80b") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280"), new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e"), new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"), new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("1241505e-4432-4724-b393-f600d3e3b80b"), new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("1241505e-4432-4724-b393-f600d3e3b80b"), new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e") });

            migrationBuilder.DeleteData(
                table: "StationRelations",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"), new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("28297ed7-db3f-42d6-8705-c2f994b0d7fc"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("7f7381f0-cd65-410c-9952-05e38779bfa3"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("9cf66913-b2f1-4c7f-91f3-053d2efbf9c1"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("007de4a2-165c-44d4-857a-009918751144"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("05451801-c66c-4646-8091-b954e49ed776"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0de4ae99-0130-49c1-a0da-6ffe53670b6a"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("1241505e-4432-4724-b393-f600d3e3b80b"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("7188f8ee-9ee8-4d33-a50e-4fcd097faa4e"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("7628362e-57a1-43ed-88f8-55d2f81f280c"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a128508a-9ef4-4cf4-b4b9-6cfd5c64838d"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("bb56545f-0f88-4fc9-97f7-3d639827f280"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("beb03d6e-1f9f-46e6-94cc-da6c1e46469e"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("fe89c47f-add6-432f-92b2-7d97db0a9baf"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("72749932-2ab1-4f2a-908c-14fc98d52782"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("ca2b41fc-d7d1-4305-9e35-a435204023f0"));

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
                keyValue: new Guid("ff65ceb7-3597-4f48-aca1-19a2d2ee8b61"));
        }
    }
}
