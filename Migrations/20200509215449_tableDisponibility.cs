using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HouseCleanersApi.Migrations
{
    public partial class tableDisponibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_jobServiceId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "jobServiceId",
                table: "Reservations",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_jobServiceId",
                table: "Reservations",
                newName: "IX_Reservations_ServiceId");

            migrationBuilder.AddColumn<bool>(
                name: "saterday",
                table: "Plannings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sunday",
                table: "Plannings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Disponibility",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(nullable: false),
                    startHour = table.Column<TimeSpan>(nullable: false),
                    EndHour = table.Column<TimeSpan>(nullable: false),
                    professionalId = table.Column<int>(nullable: false),
                    reserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibility", x => x.id);
                    table.ForeignKey(
                        name: "FK_Disponibility_Professionals_professionalId",
                        column: x => x.professionalId,
                        principalTable: "Professionals",
                        principalColumn: "professionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibility_professionalId_date_startHour_EndHour",
                table: "Disponibility",
                columns: new[] { "professionalId", "date", "startHour", "EndHour" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "serviceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Disponibility");

            migrationBuilder.DropColumn(
                name: "saterday",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "sunday",
                table: "Plannings");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Reservations",
                newName: "jobServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                newName: "IX_Reservations_jobServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_jobServiceId",
                table: "Reservations",
                column: "jobServiceId",
                principalTable: "Services",
                principalColumn: "serviceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
