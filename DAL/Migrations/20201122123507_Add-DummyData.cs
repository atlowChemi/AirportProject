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
                values: new object[] { new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"), 1, null, 0, "JFK", new DateTime(2020, 11, 15, 4, 18, 0, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), 1, null, 1, "TLV", new DateTime(2020, 11, 15, 4, 17, 34, 0, DateTimeKind.Unspecified), "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"), 2, null, 0, "IST", new DateTime(2020, 11, 15, 4, 24, 57, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), 2, null, 1, "TLV", new DateTime(2020, 11, 15, 4, 36, 29, 0, DateTimeKind.Unspecified), "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("5dd553ac-1ca7-4f74-8a59-9fdf04b6bf2e"), 3, null, 0, "SAW", new DateTime(2020, 11, 15, 4, 26, 18, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "PlannedTime", "To" },
                values: new object[] { new Guid("1a5b9b8e-3053-4a82-ae63-50fb0baeb85b"), 4, new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), 0, "STN", new DateTime(2020, 11, 15, 4, 31, 6, 0, DateTimeKind.Unspecified), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0c508047-01a1-44ef-8cec-be057b41ef41"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("f9404bbb-f2e8-457f-99ce-820df340af79"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7bde51c4-e604-47ea-915f-b0ebee89bb86"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("91626d0d-7192-4237-9b35-57415f4a2e51"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d71b316f-d856-4fab-8c9f-cfdce2522e85"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("2d390ced-43ee-447d-b7a9-ab43938691d6"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7cb2957d-5fb8-40f1-a348-8b094ecfc22c"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("f9404bbb-f2e8-457f-99ce-820df340af79") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3e8013ed-512c-4c65-8ae5-bac57cc8d726"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9cf405a3-2795-40a8-b84b-e677a0ba1d3f"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9163a421-f7fc-4294-8526-8fed851e18b9"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ef4627e3-a921-4fcc-9e0e-7e442deaa202"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("0c508047-01a1-44ef-8cec-be057b41ef41") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("cc60d1d8-d419-4ceb-8de8-5ea3fd2d0bf3"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7531b5f1-35ec-43c1-96e2-46a9aa7e1863"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("26116e7e-ba5f-439e-8f2d-115dc2b30ff3"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("a713e0c6-0e37-411c-bb1a-00b71807909f"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("a8c88a4d-b7b6-495c-a617-ef37b7abd125"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), 1, new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"), new Guid("0c508047-01a1-44ef-8cec-be057b41ef41") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345"), new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"), new Guid("f9404bbb-f2e8-457f-99ce-820df340af79") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599"), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562"), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35"), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f"), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), new Guid("5dd553ac-1ca7-4f74-8a59-9fdf04b6bf2e"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "ControlTowerId", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4"), new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("0ad27db7-eefa-49f2-9d85-fbee4236ada5"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3ac66e82-c322-4591-9901-d07ef92e43ad"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"), null, new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e8bd2749-69a9-4a65-943f-acfd67d937b8"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("ee29fafb-95f0-4485-9f66-1b23755de247") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("2c830436-bc47-4197-9550-ba80fcab62c1"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("ee29fafb-95f0-4485-9f66-1b23755de247") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("af574395-b5dc-4d6a-9310-d30787f0b53b"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("5dd553ac-1ca7-4f74-8a59-9fdf04b6bf2e"), null, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("0c508047-01a1-44ef-8cec-be057b41ef41"), new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("f9404bbb-f2e8-457f-99ce-820df340af79"), new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"), new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"), new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562") });
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
                keyValue: new Guid("0ad27db7-eefa-49f2-9d85-fbee4236ada5"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("26116e7e-ba5f-439e-8f2d-115dc2b30ff3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("2c830436-bc47-4197-9550-ba80fcab62c1"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("2d390ced-43ee-447d-b7a9-ab43938691d6"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3ac66e82-c322-4591-9901-d07ef92e43ad"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3e8013ed-512c-4c65-8ae5-bac57cc8d726"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7531b5f1-35ec-43c1-96e2-46a9aa7e1863"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7bde51c4-e604-47ea-915f-b0ebee89bb86"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7cb2957d-5fb8-40f1-a348-8b094ecfc22c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("91626d0d-7192-4237-9b35-57415f4a2e51"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9163a421-f7fc-4294-8526-8fed851e18b9"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9cf405a3-2795-40a8-b84b-e677a0ba1d3f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("a713e0c6-0e37-411c-bb1a-00b71807909f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("a8c88a4d-b7b6-495c-a617-ef37b7abd125"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("af574395-b5dc-4d6a-9310-d30787f0b53b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("cc60d1d8-d419-4ceb-8de8-5ea3fd2d0bf3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d71b316f-d856-4fab-8c9f-cfdce2522e85"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e8bd2749-69a9-4a65-943f-acfd67d937b8"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ef4627e3-a921-4fcc-9e0e-7e442deaa202"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("1a5b9b8e-3053-4a82-ae63-50fb0baeb85b"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), 1, new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"), 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"), new Guid("0c508047-01a1-44ef-8cec-be057b41ef41") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("0c508047-01a1-44ef-8cec-be057b41ef41"), new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("f9404bbb-f2e8-457f-99ce-820df340af79"), new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345"), new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562"), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35"), new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f"), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599"), new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"), new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"), new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"), new Guid("f9404bbb-f2e8-457f-99ce-820df340af79") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("218e1ceb-a5c6-44e2-b3ee-88a60e9dba7a"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("264ec1e4-c40c-4c79-8b51-f43e3603ea8b"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("26a63d59-27b8-4df0-951e-1a3ae39c48e6"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0c508047-01a1-44ef-8cec-be057b41ef41"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("3cc318d6-9761-49c8-a781-57e1e850c5f4"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("6a9a11f2-01a8-422e-8c7a-e50394564414"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("9b10881d-f4bc-4b66-acb4-b829a9e6a32f"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e38dee1b-c356-4544-9fd0-6c63a13e9599"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e4f03771-bb1f-4d8e-a891-be2b11fa8345"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("eb0974ab-2d72-4125-aeb6-0e87212f4562"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("ee29fafb-95f0-4485-9f66-1b23755de247"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("ef150cc4-b547-42f5-b127-2b56e0b58d35"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("f9404bbb-f2e8-457f-99ce-820df340af79"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("43e62229-a967-4ef6-be31-44e46f0649aa"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("5dd553ac-1ca7-4f74-8a59-9fdf04b6bf2e"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("dc2a58c6-4fb9-4d26-aaf8-de9fbfa49c4a"));

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
