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
                values: new object[] { new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), "TLV" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878"), null, "Drop passengers" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4"), null, "Drop lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1"), null, "Refuel" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae"), null, "Takeoff port 1" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"), null, "Pick lugage" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("726022fb-f31e-401b-96f4-fab4b4d31590"), null, "Pick passengers" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"), 1, null, 0, "JFK", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), 1, null, 1, "TLV", "ATH" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"), 2, null, 0, "IST", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), 2, null, 1, "TLV", "LTN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("fbd7f136-9886-45a5-9831-6209501a8b30"), 3, null, 0, "SAW", "TLV" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirplaneId", "ControlTowerId", "Direction", "From", "To" },
                values: new object[] { new Guid("0dc1fccc-0ad6-4699-b691-f37fa1f54519"), 4, new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), 0, "STN", "TLV" });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), 1, new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5"), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878"), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4"), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae"), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1"), new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"), new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"), new Guid("726022fb-f31e-401b-96f4-fab4b4d31590") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("7c8ab075-85be-4a64-beee-a20f45a8d3cb"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c8446a00-3fb7-4f58-bb55-51c8982a850f"), new DateTime(2020, 11, 15, 4, 23, 7, 0, DateTimeKind.Unspecified), new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("19122089-389f-459a-9c16-eb27ed2fadf2"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"), new DateTime(2020, 11, 15, 4, 27, 20, 0, DateTimeKind.Unspecified), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("56c91f3d-ad8d-43e3-98d7-ae4706f7be93"), new DateTime(2020, 11, 15, 4, 18, 46, 0, DateTimeKind.Unspecified), new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("e35cc34a-85f9-46f1-a79a-37943ea1db5b"), new DateTime(2020, 11, 15, 4, 20, 20, 0, DateTimeKind.Unspecified), new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("610ff5e1-a77a-4fe3-af87-aee2b9b531bd"), new DateTime(2020, 11, 15, 4, 23, 21, 0, DateTimeKind.Unspecified), new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("61cccbae-419d-4c4b-a047-6d47ccc23173"), new DateTime(2020, 11, 15, 4, 24, 19, 0, DateTimeKind.Unspecified), new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c475baf8-70a4-4b21-a598-e52e9ba3a794"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("16bf8a13-73b9-4ada-8d98-a367d8fc7e69"), new DateTime(2020, 11, 15, 4, 30, 1, 0, DateTimeKind.Unspecified), new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("46816ec4-0934-400e-97e7-c5861099e759"), new DateTime(2020, 11, 15, 4, 34, 12, 0, DateTimeKind.Unspecified), new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"), new DateTime(2020, 11, 15, 4, 38, 10, 0, DateTimeKind.Unspecified), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("65d38bfc-736a-4077-a111-444fed99752c"), new DateTime(2020, 11, 15, 5, 38, 16, 0, DateTimeKind.Unspecified), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("1ee839e4-142d-4547-8f6d-3df62e30b2a7"), new DateTime(2020, 11, 15, 5, 40, 9, 0, DateTimeKind.Unspecified), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("99b9bd05-274e-4f40-8728-ec1397c30e96"), new DateTime(2020, 11, 15, 5, 42, 47, 0, DateTimeKind.Unspecified), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("f5a51fa6-d829-432e-ba26-4da4f85fac6e"), new DateTime(2020, 11, 15, 5, 44, 31, 0, DateTimeKind.Unspecified), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("726022fb-f31e-401b-96f4-fab4b4d31590") });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661"), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), "Takeoff" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlightId", "Name" },
                values: new object[] { new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"), new Guid("fbd7f136-9886-45a5-9831-6209501a8b30"), "Land port 1" });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("3e76f017-d450-4428-aefc-3ba59665b7f4"), new DateTime(2020, 11, 15, 4, 28, 39, 0, DateTimeKind.Unspecified), new Guid("5022823a-01d8-4114-a9c6-461ed724555a"), new DateTime(2020, 11, 15, 4, 29, 3, 0, DateTimeKind.Unspecified), new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("9f4ff1df-447d-456d-a958-6593518c9122"), new DateTime(2020, 11, 15, 5, 48, 57, 0, DateTimeKind.Unspecified), new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"), null, new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("d5b0f00e-70ba-4efb-996f-2d33f2cf113d"), new DateTime(2020, 11, 15, 4, 18, 30, 0, DateTimeKind.Unspecified), new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"), new DateTime(2020, 11, 15, 4, 22, 14, 0, DateTimeKind.Unspecified), new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("c2b22daa-0d79-4d9d-b843-9dc66f813e89"), new DateTime(2020, 11, 15, 4, 24, 48, 0, DateTimeKind.Unspecified), new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"), new DateTime(2020, 11, 15, 4, 25, 31, 0, DateTimeKind.Unspecified), new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95") });

            migrationBuilder.InsertData(
                table: "FlightHistories",
                columns: new[] { "Id", "EnterStationTime", "FlightId", "LeaveStationTime", "StationId" },
                values: new object[] { new Guid("a0efd653-298c-44f4-85b8-4b17e94518e7"), new DateTime(2020, 11, 15, 4, 26, 38, 0, DateTimeKind.Unspecified), new Guid("fbd7f136-9886-45a5-9831-6209501a8b30"), null, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95") });

            migrationBuilder.InsertData(
                table: "StationControlTowerRelation",
                columns: new[] { "ControlTowerId", "Direction", "StationId" },
                values: new object[] { new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5"), new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 1, new Guid("726022fb-f31e-401b-96f4-fab4b4d31590"), new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"), new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5") });

            migrationBuilder.InsertData(
                table: "StationRelation",
                columns: new[] { "Direction", "StationFromId", "StationToId" },
                values: new object[] { 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"), new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878") });
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
                keyValue: new Guid("16bf8a13-73b9-4ada-8d98-a367d8fc7e69"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("19122089-389f-459a-9c16-eb27ed2fadf2"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("1ee839e4-142d-4547-8f6d-3df62e30b2a7"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("3e76f017-d450-4428-aefc-3ba59665b7f4"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("46816ec4-0934-400e-97e7-c5861099e759"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("56c91f3d-ad8d-43e3-98d7-ae4706f7be93"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("610ff5e1-a77a-4fe3-af87-aee2b9b531bd"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("61cccbae-419d-4c4b-a047-6d47ccc23173"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("65d38bfc-736a-4077-a111-444fed99752c"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("7c8ab075-85be-4a64-beee-a20f45a8d3cb"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("99b9bd05-274e-4f40-8728-ec1397c30e96"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("9f4ff1df-447d-456d-a958-6593518c9122"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("a0efd653-298c-44f4-85b8-4b17e94518e7"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c2b22daa-0d79-4d9d-b843-9dc66f813e89"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c475baf8-70a4-4b21-a598-e52e9ba3a794"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("c8446a00-3fb7-4f58-bb55-51c8982a850f"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("d5b0f00e-70ba-4efb-996f-2d33f2cf113d"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("e35cc34a-85f9-46f1-a79a-37943ea1db5b"));

            migrationBuilder.DeleteData(
                table: "FlightHistories",
                keyColumn: "Id",
                keyValue: new Guid("f5a51fa6-d829-432e-ba26-4da4f85fac6e"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("0dc1fccc-0ad6-4699-b691-f37fa1f54519"));

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), 1, new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae") });

            migrationBuilder.DeleteData(
                table: "StationControlTowerRelation",
                keyColumns: new[] { "ControlTowerId", "Direction", "StationId" },
                keyValues: new object[] { new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"), 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"), new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878"), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5"), new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"), new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"), new Guid("726022fb-f31e-401b-96f4-fab4b4d31590") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5"), new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("726022fb-f31e-401b-96f4-fab4b4d31590"), new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"), new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 0, new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4"), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae"), new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1") });

            migrationBuilder.DeleteData(
                table: "StationRelation",
                keyColumns: new[] { "Direction", "StationFromId", "StationToId" },
                keyValues: new object[] { 1, new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1"), new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f") });

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlTowers",
                keyColumn: "Id",
                keyValue: new Guid("e5921217-a88c-4759-b234-58d6cebc72f2"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("5022823a-01d8-4114-a9c6-461ed724555a"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("e55ca328-32a6-4089-a416-05777d8f4a4f"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("eee47d19-49a5-4814-b9b3-2c5e298da0d4"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0f0dd355-c0f3-4c85-bfac-f9745d3c6878"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0fe34372-728f-4298-819d-6fff6b4d23c4"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("1407da1f-f2d6-4b98-907f-ea96dc5c6bae"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("243cfade-99bc-4a9a-8ed5-af1dc59b6ef5"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("726022fb-f31e-401b-96f4-fab4b4d31590"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("8857623a-7ede-4cb7-ac2e-81cd62504661"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("aacc488b-32f6-40de-b3a2-5747a77611e5"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b21898d6-8326-4b91-b23c-09d39d96b2b1"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("d0579b43-6d7a-49b5-83ba-ac7c66f3992f"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("da5a2f75-3d15-4b83-b142-9503bdf46d95"));

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("d3560b46-9a68-40cc-a391-bb4d52b2af77"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("fbd7f136-9886-45a5-9831-6209501a8b30"));

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
