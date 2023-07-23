using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.Migrations
{
    public partial class addtableCityWardDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Customers",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_LocationID",
                table: "Customers",
                newName: "IX_Customers_City");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_District_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "cityId");
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_District",
                table: "Customers",
                column: "District");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Ward",
                table: "Customers",
                column: "Ward");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                table: "District",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                table: "Ward",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_City_City",
                table: "Customers",
                column: "City",
                principalTable: "City",
                principalColumn: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_District_District",
                table: "Customers",
                column: "District",
                principalTable: "District",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ward_Ward",
                table: "Customers",
                column: "Ward",
                principalTable: "Ward",
                principalColumn: "WardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_City_City",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_District_District",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ward_Ward",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Customers_District",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Ward",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_City",
                table: "Customers",
                newName: "IX_Customers_LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationID",
                table: "Customers",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
