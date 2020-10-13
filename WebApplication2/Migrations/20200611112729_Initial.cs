using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faiths",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faiths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "polities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Mainland = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    FaithId = table.Column<Guid>(nullable: true),
                    PolityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_countries_faiths_FaithId",
                        column: x => x.FaithId,
                        principalTable: "faiths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_countries_polities_PolityId",
                        column: x => x.PolityId,
                        principalTable: "polities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countries_FaithId",
                table: "countries",
                column: "FaithId");

            migrationBuilder.CreateIndex(
                name: "IX_countries_PolityId",
                table: "countries",
                column: "PolityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "faiths");

            migrationBuilder.DropTable(
                name: "polities");
        }
    }
}
