using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commissionTotal",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "pourcentCommission",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "preCommission",
                table: "InvoiceLines");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Services",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Services");

            migrationBuilder.AddColumn<decimal>(
                name: "commissionTotal",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pourcentCommission",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "preCommission",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
