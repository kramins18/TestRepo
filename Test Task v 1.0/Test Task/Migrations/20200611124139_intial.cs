using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Task.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    ID_House = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostIndex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.ID_House);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ID_Apartment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<int>(nullable: false),
                    ApartmentFloor = table.Column<int>(nullable: false),
                    RoomCount = table.Column<int>(nullable: false),
                    ResidentsCount = table.Column<int>(nullable: false),
                    FullArea = table.Column<double>(nullable: false),
                    FivingArea = table.Column<double>(nullable: false),
                    ID_House = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ID_Apartment);
                    table.ForeignKey(
                        name: "FK_Apartments_House_ID_House",
                        column: x => x.ID_House,
                        principalTable: "House",
                        principalColumn: "ID_House",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ID_Reasident = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PersonalNo = table.Column<string>(nullable: true),
                    BirthDat = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    ID_Apartment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ID_Reasident);
                    table.ForeignKey(
                        name: "FK_Residents_Apartments_ID_Apartment",
                        column: x => x.ID_Apartment,
                        principalTable: "Apartments",
                        principalColumn: "ID_Apartment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ID_House",
                table: "Apartments",
                column: "ID_House");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_ID_Apartment",
                table: "Residents",
                column: "ID_Apartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
