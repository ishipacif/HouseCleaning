using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_categoryName",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_categoryName",
                table: "Categories",
                column: "categoryName");
        }
    }
}
