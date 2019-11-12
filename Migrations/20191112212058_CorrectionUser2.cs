using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class CorrectionUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Professionals");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_userId",
                table: "Customers",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_userId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_userId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Professionals",
                type: "text",
                nullable: true);
        }
    }
}
