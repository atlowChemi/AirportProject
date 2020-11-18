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
                values: new object[] { new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("6924b392-9367-4ff5-b86c-914da3e48998"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("ee45404b-c63d-425e-9133-58e730c2010d"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("db562c5d-8701-46ce-8817-a90fadfe991f"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"), 1, null, 0, "JFK", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), 1, null, 1, "TLV", "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"), 2, null, 0, "IST", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), 2, null, 1, "TLV", "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("f35fe4e2-54b4-486c-9ba2-2261da5a8cd8"), 3, null, 0, "SAW", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("8bedf3e1-0646-44d3-a1e3-64d1f476f9b3"), 4, new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), 0, "STN", "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), 1, new Guid("db562c5d-8701-46ce-8817-a90fadfe991f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656"), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e"), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("6924b392-9367-4ff5-b86c-914da3e48998"), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("db562c5d-8701-46ce-8817-a90fadfe991f"), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("ee45404b-c63d-425e-9133-58e730c2010d"), new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"), new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"), new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d6b4c84b-185b-4f73-9965-47a95e2d5034"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("cbf8a0f6-cb97-4585-9353-46aa01594c3c"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ac35331f-6af1-4b8d-bd33-21936a1029bc"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("02704e6b-a435-4f38-ba62-034a7d649984"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("db562c5d-8701-46ce-8817-a90fadfe991f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("30cdf3f4-fbfe-4ed3-afaa-23f90fd681f1"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("b880d4b6-40e1-475b-b827-04d776860b17"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("48121608-384d-4429-8a4a-79af664980d3"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3cd38f60-a910-4de7-998e-256a82b0020c"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("6561af5e-77b0-427c-8c6c-eacd316544d5"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e571993e-0473-4cca-b332-a52348e72a5f"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("6c59cbdd-ac80-4e7a-9da5-6a120f959fce"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("db562c5d-8701-46ce-8817-a90fadfe991f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("57089fa1-d7ba-4b94-8313-f5fa53412764"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("715533c2-d90c-4f47-94f9-95c5494afd65"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3158d2f0-42af-467d-a9ed-c0c445c45b8f"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307"), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"), new Guid("f35fe4e2-54b4-486c-9ba2-2261da5a8cd8"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1157aa0e-a4db-4c1d-912a-2e569d4aff26"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("60e01193-065b-4651-8e00-1fb2bdb97f7e"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"), null, new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("52d00766-f3c4-4385-af09-351b0c1c3e4f"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("ec920831-1c94-4f1f-b151-e92918494f96"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("8a7d546d-5105-4e83-8262-82c5cc51f145"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("f35fe4e2-54b4-486c-9ba2-2261da5a8cd8"), null, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationToId" },
                values: new object[] { new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f"), new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49"), new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"), new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"), new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e") });
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
                keyValue: new Guid("02704e6b-a435-4f38-ba62-034a7d649984"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1157aa0e-a4db-4c1d-912a-2e569d4aff26"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("30cdf3f4-fbfe-4ed3-afaa-23f90fd681f1"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3158d2f0-42af-467d-a9ed-c0c445c45b8f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3cd38f60-a910-4de7-998e-256a82b0020c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("48121608-384d-4429-8a4a-79af664980d3"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("52d00766-f3c4-4385-af09-351b0c1c3e4f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("57089fa1-d7ba-4b94-8313-f5fa53412764"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("60e01193-065b-4651-8e00-1fb2bdb97f7e"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("6561af5e-77b0-427c-8c6c-eacd316544d5"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("6c59cbdd-ac80-4e7a-9da5-6a120f959fce"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("715533c2-d90c-4f47-94f9-95c5494afd65"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("8a7d546d-5105-4e83-8262-82c5cc51f145"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ac35331f-6af1-4b8d-bd33-21936a1029bc"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("b880d4b6-40e1-475b-b827-04d776860b17"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("cbf8a0f6-cb97-4585-9353-46aa01594c3c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d6b4c84b-185b-4f73-9965-47a95e2d5034"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e571993e-0473-4cca-b332-a52348e72a5f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("ec920831-1c94-4f1f-b151-e92918494f96"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("8bedf3e1-0646-44d3-a1e3-64d1f476f9b3"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationToId" },
                keyValues: new object[] { new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"), 1, new Guid("db562c5d-8701-46ce-8817-a90fadfe991f") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e"), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656"), new Guid("6924b392-9367-4ff5-b86c-914da3e48998") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"), new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"), new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"), new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49"), new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f"), new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("ee45404b-c63d-425e-9133-58e730c2010d"), new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("6924b392-9367-4ff5-b86c-914da3e48998"), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("db562c5d-8701-46ce-8817-a90fadfe991f"), new Guid("ee45404b-c63d-425e-9133-58e730c2010d") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"), new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("d33db14e-7ff8-4cfe-8b99-55e6f7b364a8"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("3880d9ae-ae40-4a38-a058-5442b012dd66"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("50f7e8bf-7924-4a74-8c2b-5ffe1cec064e"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("66d449df-d1d5-4f8f-b4dd-b9cdc1a773c6"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0f8aa583-c35d-452f-a275-4ed792b7f645"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("6924b392-9367-4ff5-b86c-914da3e48998"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("74873abc-bb33-444f-bb3a-a91ff4d49b49"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("892da281-1edd-4254-980f-b7b7bbe0b53e"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c3485e28-656d-4aad-84d8-aa16a867c80f"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("da3d4fa3-c710-42fc-b613-a78b465b3307"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("db562c5d-8701-46ce-8817-a90fadfe991f"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("ea208cf0-9042-4e92-b11e-c7174d6db48e"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("ee45404b-c63d-425e-9133-58e730c2010d"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("f9290460-fdae-4919-976e-bfaf5b9c8656"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("1821509e-f07c-4fa3-b42e-266ff7209de7"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("f35fe4e2-54b4-486c-9ba2-2261da5a8cd8"));

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
