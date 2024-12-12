using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class manymany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guides",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guides", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registeres",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registeres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numRegisteres = table.Column<int>(type: "int", nullable: false),
                    idGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guideid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.code);
                    table.ForeignKey(
                        name: "FK_trips_guides_guideid",
                        column: x => x.guideid,
                        principalTable: "guides",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteresTrip",
                columns: table => new
                {
                    registeresid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tripscode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteresTrip", x => new { x.registeresid, x.tripscode });
                    table.ForeignKey(
                        name: "FK_RegisteresTrip_registeres_registeresid",
                        column: x => x.registeresid,
                        principalTable: "registeres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteresTrip_trips_tripscode",
                        column: x => x.tripscode,
                        principalTable: "trips",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteresTrip_tripscode",
                table: "RegisteresTrip",
                column: "tripscode");

            migrationBuilder.CreateIndex(
                name: "IX_trips_guideid",
                table: "trips",
                column: "guideid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteresTrip");

            migrationBuilder.DropTable(
                name: "registeres");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "guides");
        }
    }
}
