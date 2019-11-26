using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId1",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Professionals_ProfessionalId1",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_Professionals_ProfessionalId1",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Plannings_ProfessionalId1",
                table: "Plannings");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProfessionalId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProfessionalId1",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProfessionalId1",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "Plannings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_ProfessionalId",
                table: "Plannings",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProfessionalId",
                table: "Invoices",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Professionals_ProfessionalId",
                table: "Invoices",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plannings_Professionals_ProfessionalId",
                table: "Plannings",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Professionals_ProfessionalId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_Professionals_ProfessionalId",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Plannings_ProfessionalId",
                table: "Plannings");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProfessionalId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Services",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId1",
                table: "Plannings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Invoices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId1",
                table: "Invoices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId1",
                table: "Services",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_ProfessionalId1",
                table: "Plannings",
                column: "ProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId1",
                table: "Invoices",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProfessionalId1",
                table: "Invoices",
                column: "ProfessionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId1",
                table: "Invoices",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Professionals_ProfessionalId1",
                table: "Invoices",
                column: "ProfessionalId1",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plannings_Professionals_ProfessionalId1",
                table: "Plannings",
                column: "ProfessionalId1",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId1",
                table: "Services",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
