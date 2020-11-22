using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AirLine = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlTowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlTowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: true),
                    From = table.Column<string>(type: "TEXT", nullable: true),
                    PlannedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Direction = table.Column<int>(type: "INTEGER", nullable: false),
                    AirplaneId = table.Column<int>(type: "INTEGER", nullable: false),
                    ControlTowerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_ControlTowers_ControlTowerId",
                        column: x => x.ControlTowerId,
                        principalTable: "ControlTowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentFlightId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ControlTowerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_ControlTowers_ControlTowerId",
                        column: x => x.ControlTowerId,
                        principalTable: "ControlTowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_Flights_CurrentFlightId",
                        column: x => x.CurrentFlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnterStationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LeaveStationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FlightId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightHistories_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightHistories_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationControlTowerRelation",
                columns: table => new
                {
                    Direction = table.Column<int>(type: "INTEGER", nullable: false),
                    StationToId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ControlTowerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationControlTowerRelation", x => new { x.StationToId, x.Direction, x.ControlTowerId });
                    table.ForeignKey(
                        name: "FK_StationControlTowerRelation_ControlTowers_ControlTowerId",
                        column: x => x.ControlTowerId,
                        principalTable: "ControlTowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationControlTowerRelation_Stations_StationToId",
                        column: x => x.StationToId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationRelation",
                columns: table => new
                {
                    StationFromId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StationToId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Direction = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationRelation", x => new { x.StationToId, x.StationFromId, x.Direction });
                    table.ForeignKey(
                        name: "FK_StationRelation_Stations_StationFromId",
                        column: x => x.StationFromId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationRelation_Stations_StationToId",
                        column: x => x.StationToId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlTowers_Name",
                table: "ControlTowers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightHistories_FlightId",
                table: "FlightHistories",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightHistories_StationId",
                table: "FlightHistories",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ControlTowerId",
                table: "Flights",
                column: "ControlTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_StationControlTowerRelation_ControlTowerId",
                table: "StationControlTowerRelation",
                column: "ControlTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_StationControlTowerRelation_StationToId",
                table: "StationControlTowerRelation",
                column: "StationToId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationRelation_StationFromId",
                table: "StationRelation",
                column: "StationFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_ControlTowerId",
                table: "Stations",
                column: "ControlTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CurrentFlightId",
                table: "Stations",
                column: "CurrentFlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightHistories");

            migrationBuilder.DropTable(
                name: "StationControlTowerRelation");

            migrationBuilder.DropTable(
                name: "StationRelation");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "ControlTowers");
        }
    }
}
