using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class correctionservicepro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionalsProfessionalId",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProfessionalsProfessionalId",
                table: "Services",
                column: "ProfessionalsProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Professionals_ProfessionalsProfessionalId",
                table: "Services",
                column: "ProfessionalsProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Professionals_ProfessionalsProfessionalId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProfessionalsProfessionalId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProfessionalsProfessionalId",
                table: "Services");
        }
    }
}
