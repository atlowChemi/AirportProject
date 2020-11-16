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
                values: new object[] { new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("55b905c0-aa79-430a-9c72-300c0356b302"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("20df2404-6a0b-4237-b1a5-228ea7120355"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("89214a22-3793-4e62-8f43-efa4512e7045"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"), 1, null, 0, "JFK", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), 1, null, 1, "TLV", "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"), 2, null, 0, "IST", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), 2, null, 1, "TLV", "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("3abf2fd5-c083-42a0-bc3e-f36bf8049271"), 3, null, 0, "SAW", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("8fbea07d-77fb-4e51-b83e-a69eda4f5038"), 4, new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), 0, "STN", "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), 1, new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c"), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("20df2404-6a0b-4237-b1a5-228ea7120355"), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d"), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5"), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("89214a22-3793-4e62-8f43-efa4512e7045"), new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"), new Guid("55b905c0-aa79-430a-9c72-300c0356b302") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"), new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9fc78eb4-d6fb-4bb1-b794-751ad6ac1289"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("20df2404-6a0b-4237-b1a5-228ea7120355") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7ad1d42e-82b8-439c-bc93-4608c999d1e4"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("8af01802-88fa-48d1-9728-cd1b41bbd073"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("90406242-f971-4b74-be0d-6e4e800098ec"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("433b4b8e-aecd-4336-a6c4-d50037404c3c"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("539183d5-e906-4083-909d-56a8f1d6a6c3"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1ac2b483-c1be-4122-9e30-4958936b6235"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("55b905c0-aa79-430a-9c72-300c0356b302") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("2b03cf38-a107-48d8-8d82-b16f013267de"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("66c8cdce-0270-4de5-ab60-014acb44df52"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("dff6995b-78ba-4e8a-ab33-7f21bfc94f0d"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("0c6ad9b4-081c-4cbe-b9c7-3fb24967cb17"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ea80c4fb-1b3b-4563-b597-f44dbe644b35"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7a983e9d-92b5-454b-937c-aca653b22bcf"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("206e0220-4cc4-41a2-b61f-ed53df704b2e"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598"), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"), new Guid("3abf2fd5-c083-42a0-bc3e-f36bf8049271"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("89baf05e-2014-4273-b25a-a9539984e584"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("4b886d17-b357-40c6-b7d3-fe23d489684c"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"), null, new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("44539f4b-3a81-40f7-8243-0546e694707b"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("4531e577-fe21-4243-987c-be69984adc54"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("03c3721a-85b1-4058-9006-fff0c1f59845"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("3abf2fd5-c083-42a0-bc3e-f36bf8049271"), null, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("55b905c0-aa79-430a-9c72-300c0356b302"), new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69"), new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"), new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"), new Guid("20df2404-6a0b-4237-b1a5-228ea7120355") });
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
                keyValue: new Guid("03c3721a-85b1-4058-9006-fff0c1f59845"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("0c6ad9b4-081c-4cbe-b9c7-3fb24967cb17"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1ac2b483-c1be-4122-9e30-4958936b6235"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("206e0220-4cc4-41a2-b61f-ed53df704b2e"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("2b03cf38-a107-48d8-8d82-b16f013267de"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("433b4b8e-aecd-4336-a6c4-d50037404c3c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("44539f4b-3a81-40f7-8243-0546e694707b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("4531e577-fe21-4243-987c-be69984adc54"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("4b886d17-b357-40c6-b7d3-fe23d489684c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("539183d5-e906-4083-909d-56a8f1d6a6c3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("66c8cdce-0270-4de5-ab60-014acb44df52"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7a983e9d-92b5-454b-937c-aca653b22bcf"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7ad1d42e-82b8-439c-bc93-4608c999d1e4"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("89baf05e-2014-4273-b25a-a9539984e584"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("8af01802-88fa-48d1-9728-cd1b41bbd073"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("90406242-f971-4b74-be0d-6e4e800098ec"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9fc78eb4-d6fb-4bb1-b794-751ad6ac1289"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("dff6995b-78ba-4e8a-ab33-7f21bfc94f0d"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ea80c4fb-1b3b-4563-b597-f44dbe644b35"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("8fbea07d-77fb-4e51-b83e-a69eda4f5038"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"), 1, new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"), new Guid("20df2404-6a0b-4237-b1a5-228ea7120355") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"), new Guid("55b905c0-aa79-430a-9c72-300c0356b302") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"), new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("89214a22-3793-4e62-8f43-efa4512e7045"), new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5"), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d"), new Guid("89214a22-3793-4e62-8f43-efa4512e7045") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("20df2404-6a0b-4237-b1a5-228ea7120355"), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c"), new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"), new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("55b905c0-aa79-430a-9c72-300c0356b302"), new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69"), new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("e25df7f2-f08c-4b23-b479-4ede7f1d92b4"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("00ad3e68-9e10-46da-96a8-3f7ac3332483"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("7f18e7fc-70cc-4394-b505-f7192710f397"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("a7de0043-fbf5-44e3-bcfe-7610d0ad49cc"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("20df2404-6a0b-4237-b1a5-228ea7120355"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("55b905c0-aa79-430a-9c72-300c0356b302"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("6acecce8-1ab7-42e6-8ec0-deb96ad77008"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("73c1cdd7-f7d6-411f-a4d8-f42ba4dca73c"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("7eb43542-a744-4399-a5d2-c0fe2832bee6"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("83aa9985-4090-44f1-957e-5d306ecc86d5"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("89214a22-3793-4e62-8f43-efa4512e7045"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("9ba75bc1-7cbc-44c4-ade9-1c8eb7b5ab9d"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a727aa36-b382-4ce1-ab7a-c6eb064c5b69"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c24a35ac-84f2-4aa2-9fc5-d9581c83c598"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("3abf2fd5-c083-42a0-bc3e-f36bf8049271"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("791b2552-05d9-47a7-95ac-081f8d9a4418"));

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
