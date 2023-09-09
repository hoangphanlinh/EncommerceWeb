using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.Migrations
{
    public partial class addNewsDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CatID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CatID",
                table: "Posts",
                newName: "NewDirID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CatID",
                table: "Posts",
                newName: "IX_Posts_NewDirID");

            migrationBuilder.CreateTable(
                name: "NewsDirectories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDirectories", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_NewsDirectories_NewDirID",
                table: "Posts",
                column: "NewDirID",
                principalTable: "NewsDirectories",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_NewsDirectories_NewDirID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "NewsDirectories");

            migrationBuilder.RenameColumn(
                name: "NewDirID",
                table: "Posts",
                newName: "CatID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_NewDirID",
                table: "Posts",
                newName: "IX_Posts_CatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CatID",
                table: "Posts",
                column: "CatID",
                principalTable: "Categories",
                principalColumn: "CatID");
        }
    }
}
