using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteAPI_SQL_Connect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    LocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.LocalID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "SubLocals",
                columns: table => new
                {
                    SubLocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FloorLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLocals", x => x.SubLocalID);
                    table.ForeignKey(
                        name: "FK_SubLocals_Locals_LocalID",
                        column: x => x.LocalID,
                        principalTable: "Locals",
                        principalColumn: "LocalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Devices_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    BeaconID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubLocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    UuidString = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CoordinateX = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    BatteryLevel = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacons", x => x.BeaconID);
                    table.ForeignKey(
                        name: "FK_Beacons_SubLocals_SubLocalID",
                        column: x => x.SubLocalID,
                        principalTable: "SubLocals",
                        principalColumn: "SubLocalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointsOfInterest",
                columns: table => new
                {
                    PoiID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubLocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoordinateX = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfInterest", x => x.PoiID);
                    table.ForeignKey(
                        name: "FK_PointsOfInterest_SubLocals_SubLocalID",
                        column: x => x.SubLocalID,
                        principalTable: "SubLocals",
                        principalColumn: "SubLocalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositioningLogs",
                columns: table => new
                {
                    LogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeaconID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalculatedX = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    CalculatedY = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    CapturedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositioningLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_PositioningLogs_Beacons_BeaconID",
                        column: x => x.BeaconID,
                        principalTable: "Beacons",
                        principalColumn: "BeaconID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositioningLogs_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_SubLocalID",
                table: "Beacons",
                column: "SubLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PersonID",
                table: "Devices",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfInterest_SubLocalID",
                table: "PointsOfInterest",
                column: "SubLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_PositioningLogs_BeaconID",
                table: "PositioningLogs",
                column: "BeaconID");

            migrationBuilder.CreateIndex(
                name: "IX_PositioningLogs_PersonID",
                table: "PositioningLogs",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SubLocals_LocalID",
                table: "SubLocals",
                column: "LocalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PointsOfInterest");

            migrationBuilder.DropTable(
                name: "PositioningLogs");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SubLocals");

            migrationBuilder.DropTable(
                name: "Locals");
        }
    }
}
