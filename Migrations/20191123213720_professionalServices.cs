using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class professionalServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalServices",
                columns: table => new
                {
                    professionalId = table.Column<int>(nullable: false),
                    serviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalServices", x => new { x.professionalId, x.serviceId });
                    table.ForeignKey(
                        name: "FK_ProfessionalServices_Professionals_professionalId",
                        column: x => x.professionalId,
                        principalTable: "Professionals",
                        principalColumn: "ProfessionalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalServices_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServices_serviceId",
                table: "ProfessionalServices",
                column: "serviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalServices");
        }
    }
}
