using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class renamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId1",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Reservations_ReservationId1",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Professionals_ProfessionalsProfessionalId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProfessionalsProfessionalId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_InvoiceId1",
                table: "InvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_ReservationId1",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "ProfessionalsProfessionalId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InvoiceId1",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "InvoiceLines");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "InvoiceLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProfessionalId",
                table: "Services",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ReservationId",
                table: "InvoiceLines",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Reservations_ReservationId",
                table: "InvoiceLines",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Professionals_ProfessionalId",
                table: "Services",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Reservations_ReservationId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Professionals_ProfessionalId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProfessionalId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_ReservationId",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "InvoiceLines");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalsProfessionalId",
                table: "Services",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId1",
                table: "InvoiceLines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "InvoiceLines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProfessionalsProfessionalId",
                table: "Services",
                column: "ProfessionalsProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId1",
                table: "InvoiceLines",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ReservationId1",
                table: "InvoiceLines",
                column: "ReservationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId1",
                table: "InvoiceLines",
                column: "InvoiceId1",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Reservations_ReservationId1",
                table: "InvoiceLines",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Professionals_ProfessionalsProfessionalId",
                table: "Services",
                column: "ProfessionalsProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
