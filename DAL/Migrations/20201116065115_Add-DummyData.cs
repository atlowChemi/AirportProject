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
                column: "Id",
                value: new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"));

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("9794e328-4991-4200-b533-bc9edf259b4b"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"), 1, null, 0, "JFK", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), 1, null, 1, "TLV", "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"), 2, null, 0, "IST", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), 2, null, 1, "TLV", "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("7f4de68f-c1ff-4293-85bf-1a5c0ea6e4d4"), 3, null, 0, "SAW", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("b620cdb9-9d78-42af-aa64-030c9c442bd5"), 4, new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"), 0, "STN", "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"), 1, new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639"), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b"), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c"), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62"), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f"), new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"), new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"), new Guid("9794e328-4991-4200-b533-bc9edf259b4b") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("6be6f7c9-c86e-4923-bd90-30580b26b962"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9dda3443-389e-48d7-8eea-5edd01322f71"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("226bbb90-5b6e-4b02-a4b0-f123e9d2a284"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c34da3ab-7352-4ecd-aa2a-480170e4c240"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e5782d57-1ee6-42a4-8a28-910f14534955"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("77fd0e49-f5e8-4655-83b7-286c65e89bf0"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e7a8d3b6-f09a-46b1-b35b-49a125fe83af"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("0e48114f-1b8c-49ab-aa50-ed801621ecda"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("05e0984a-13da-40f1-a79b-7460a9d29623"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("33763bfa-b38d-48e5-a163-23f3ef27ee87"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ba3146b5-b9f4-45b5-9e8f-af4a3384e5e0"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("92006c7d-9331-4ddf-9203-a807e23e99f3"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("5a0029d2-af86-4ca9-b2d5-50dfbfb7432b"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d808007b-5820-4fd2-85c1-81bef1c3eac6"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("9794e328-4991-4200-b533-bc9edf259b4b") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db"), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"), new Guid("7f4de68f-c1ff-4293-85bf-1a5c0ea6e4d4"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("bb867d0f-b5d2-4fc0-90b1-73c2a8a3d62f"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("aa3d187a-3e10-4695-ba70-1d5573395feb"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"), null, new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("8e833fe0-4226-4dbe-95ed-9416bdbacc2e"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("24a5c0fd-7bc9-46e1-9a73-aa1a1033196b"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("b90fbb7e-c339-4b8a-be52-193f76545ac9"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("7f4de68f-c1ff-4293-85bf-1a5c0ea6e4d4"), null, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"), 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca"), new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("9794e328-4991-4200-b533-bc9edf259b4b"), new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"), new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"), new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b") });
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
                keyValue: new Guid("05e0984a-13da-40f1-a79b-7460a9d29623"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("0e48114f-1b8c-49ab-aa50-ed801621ecda"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("226bbb90-5b6e-4b02-a4b0-f123e9d2a284"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("24a5c0fd-7bc9-46e1-9a73-aa1a1033196b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("33763bfa-b38d-48e5-a163-23f3ef27ee87"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("5a0029d2-af86-4ca9-b2d5-50dfbfb7432b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("6be6f7c9-c86e-4923-bd90-30580b26b962"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("77fd0e49-f5e8-4655-83b7-286c65e89bf0"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("8e833fe0-4226-4dbe-95ed-9416bdbacc2e"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("92006c7d-9331-4ddf-9203-a807e23e99f3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9dda3443-389e-48d7-8eea-5edd01322f71"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("aa3d187a-3e10-4695-ba70-1d5573395feb"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("b90fbb7e-c339-4b8a-be52-193f76545ac9"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ba3146b5-b9f4-45b5-9e8f-af4a3384e5e0"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("bb867d0f-b5d2-4fc0-90b1-73c2a8a3d62f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c34da3ab-7352-4ecd-aa2a-480170e4c240"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d808007b-5820-4fd2-85c1-81bef1c3eac6"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e5782d57-1ee6-42a4-8a28-910f14534955"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e7a8d3b6-f09a-46b1-b35b-49a125fe83af"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("b620cdb9-9d78-42af-aa64-030c9c442bd5"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"), 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"), 1, new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"), new Guid("9794e328-4991-4200-b533-bc9edf259b4b") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b"), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639"), new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"), new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"), new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c"), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62"), new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f"), new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"), new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("9794e328-4991-4200-b533-bc9edf259b4b"), new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca"), new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("712aac16-0f87-4d13-b41d-3de864d6eb32"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("2d291947-3d69-4c2c-b28a-88dfd66828cd"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("99d984d2-90c9-4e21-8693-16c1f72c7817"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("d95adee0-48a1-4115-ac3d-0f3cb32c6bb1"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("7e4628a0-c9cc-48ee-9a8a-ed7e47619852"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("9794e328-4991-4200-b533-bc9edf259b4b"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a69569cd-9604-41cb-b597-27f0f0b5446c"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b67283bc-6b2b-46e5-8d67-edc7ca3f9d62"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c31d7156-7ae9-4834-8f2d-0d7888859d4b"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c552cc3e-0eae-4809-9d85-1dea6d026639"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c7f97163-9ef4-4aa7-8e41-f3e43d59ee7f"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("dd322ed6-ab06-412f-b194-f91dd482e4f7"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("f1bae558-de55-44cf-bcb5-0ec2eee1a5ca"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("fff7f93f-8ca1-47ad-927e-970ea2b509db"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("5bba3497-1fa5-4f55-94f4-a9c664bb0e4c"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("7f4de68f-c1ff-4293-85bf-1a5c0ea6e4d4"));

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
