using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWebApp.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    width = table.Column<int>(nullable: false),
                    depth = table.Column<int>(nullable: false),
                    drawerNum = table.Column<int>(nullable: false),
                    materialType = table.Column<string>(maxLength: 10, nullable: false),
                    rushDays = table.Column<int>(nullable: false),
                    desktopMaterial = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deskID = table.Column<int>(nullable: true),
                    purchaseDate = table.Column<DateTime>(nullable: false),
                    firstName = table.Column<string>(maxLength: 60, nullable: false),
                    lastName = table.Column<string>(maxLength: 60, nullable: false),
                    sizeCost = table.Column<int>(nullable: false),
                    drawerCost = table.Column<int>(nullable: false),
                    materialCost = table.Column<int>(nullable: false),
                    rushCost = table.Column<int>(nullable: false),
                    totalCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteID);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_deskID",
                        column: x => x.deskID,
                        principalTable: "Desk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_deskID",
                table: "DeskQuote",
                column: "deskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
