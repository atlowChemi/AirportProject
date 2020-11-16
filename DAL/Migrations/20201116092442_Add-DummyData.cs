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
                values: new object[] { new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("62b120ef-33e2-4190-b796-c73427933f0e"), 1, null, 0, "JFK", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), 1, null, 1, "TLV", "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("5358068e-0385-4753-90dc-12d0461c04d4"), 2, null, 0, "IST", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), 2, null, 1, "TLV", "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"), 3, null, 0, "SAW", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("dfd8b75c-b624-4a30-8d6e-c77afd746201"), 4, new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), 0, "STN", "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), 1, new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"), new Guid("3487aa5c-1660-4833-a1a4-7809055fde13") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"), new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"), new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1b0db67e-aadd-4c9d-813d-04857fcc6207"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("62b120ef-33e2-4190-b796-c73427933f0e"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("068f2bae-b304-4b54-8398-f776b278238a"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("62b120ef-33e2-4190-b796-c73427933f0e"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("163e5855-813a-43c8-8a49-17c2cc045f57"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("62b120ef-33e2-4190-b796-c73427933f0e"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("be5c2155-e808-43f1-ba29-dabcc78062f0"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9cff5f24-0845-4fa9-9eee-afba08d6f2db"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("b2a12006-9d89-4b20-8d85-a365f748978b"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("3487aa5c-1660-4833-a1a4-7809055fde13") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("4a825c82-5858-4636-bc02-80fdb4d1df30"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("0b93fe0c-7b08-43fa-af91-3f8ec703d78f"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("5358068e-0385-4753-90dc-12d0461c04d4"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("37cf10bf-e950-4276-9fe1-91ed7db9e2fa"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("5358068e-0385-4753-90dc-12d0461c04d4"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9e0f0200-621b-4874-9e03-4bdbb7bed9a8"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("5358068e-0385-4753-90dc-12d0461c04d4"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c8ef531a-0641-4dba-a7fa-7098898e64b5"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("8b65acc7-6e06-4699-b3da-71c3d4cc6eb2"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("02d8b3ab-9a33-4e6b-a41e-69f7a31e3e95"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("3487aa5c-1660-4833-a1a4-7809055fde13") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1b240fc7-82e7-45b3-b3c3-e457e42ad718"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36"), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"), new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("b37f421f-bb6e-478e-a03c-6ec253b5983c"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("fd5d2fa2-994a-4b45-b7b2-9293baec9ad1"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"), null, new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("520155bb-706f-4a20-9e65-196350e11ae4"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("62b120ef-33e2-4190-b796-c73427933f0e"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("26aa3702-2d8c-4958-8526-6b12707e59f1"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("5358068e-0385-4753-90dc-12d0461c04d4"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("27642efe-6f3a-4b38-a096-0338d70838e0"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"), null, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"), new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"), new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"), new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"), new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34") });
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
                keyValue: new Guid("02d8b3ab-9a33-4e6b-a41e-69f7a31e3e95"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("068f2bae-b304-4b54-8398-f776b278238a"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("0b93fe0c-7b08-43fa-af91-3f8ec703d78f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("163e5855-813a-43c8-8a49-17c2cc045f57"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1b0db67e-aadd-4c9d-813d-04857fcc6207"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1b240fc7-82e7-45b3-b3c3-e457e42ad718"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("26aa3702-2d8c-4958-8526-6b12707e59f1"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("27642efe-6f3a-4b38-a096-0338d70838e0"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("37cf10bf-e950-4276-9fe1-91ed7db9e2fa"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("4a825c82-5858-4636-bc02-80fdb4d1df30"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("520155bb-706f-4a20-9e65-196350e11ae4"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("8b65acc7-6e06-4699-b3da-71c3d4cc6eb2"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9cff5f24-0845-4fa9-9eee-afba08d6f2db"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9e0f0200-621b-4874-9e03-4bdbb7bed9a8"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("b2a12006-9d89-4b20-8d85-a365f748978b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("b37f421f-bb6e-478e-a03c-6ec253b5983c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("be5c2155-e808-43f1-ba29-dabcc78062f0"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c8ef531a-0641-4dba-a7fa-7098898e64b5"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("fd5d2fa2-994a-4b45-b7b2-9293baec9ad1"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("dfd8b75c-b624-4a30-8d6e-c77afd746201"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), 1, new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"), 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"), new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"), new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"), new Guid("3487aa5c-1660-4833-a1a4-7809055fde13") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"), new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"), new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"), new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"), new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"), new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"), new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("f0ca5a36-02c4-4e74-820e-eeed20605191"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("5358068e-0385-4753-90dc-12d0461c04d4"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("62b120ef-33e2-4190-b796-c73427933f0e"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("afedcee1-1c84-4a84-8391-e8652f5a38ed"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("1a00ce5a-8a1c-44f1-846d-335250f9d3dd"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("2bed4f6f-1cb3-45ee-9d3b-06b60b32acad"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("3487aa5c-1660-4833-a1a4-7809055fde13"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("619c1cef-6380-4d84-a3a5-a426526c2aee"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("94356a19-e4b3-4a88-95d2-8645c8f9b7db"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a0d07c8d-91e8-4382-b004-f14c15b7b9b2"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a4780f67-afe2-4ba8-b751-da6fa950ee36"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b47a8452-55ac-412e-8c6a-f2bbde178239"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("bf14e8cb-4fee-4709-bba6-f398e0ad44e0"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("fce398cc-0d39-4292-99b8-b84bc5144f34"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("7f18b05f-4117-48f1-8263-04f19255fe8c"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("b7cf621c-31c7-4c15-8d6f-7fbd60c7cf95"));

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
