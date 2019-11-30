using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Categories_categoryName",
                table: "Categories",
                newName: "uniquecategorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "uniquecategorie",
                table: "Categories",
                newName: "IX_Categories_categoryName");
        }
    }
}
