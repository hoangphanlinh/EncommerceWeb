using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.Migrations
{
    public partial class updatetablecustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Ward",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_City_City",
                table: "Customers",
                column: "City",
                principalTable: "City",
                principalColumn: "cityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_District_District",
                table: "Customers",
                column: "District",
                principalTable: "District",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ward_Ward",
                table: "Customers",
                column: "Ward",
                principalTable: "Ward",
                principalColumn: "WardId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "Ward",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
