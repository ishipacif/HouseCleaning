using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseCleanersApi.Migrations
{
    public partial class capitalLetterChamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Reservations_ReservationId",
                table: "InvoiceLines");

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
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Professionals_ProfessionalId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Status_StatusId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Professionals_ProfessionalId",
                table: "Services");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_CategoryName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "Status",
                newName: "statusName");

            migrationBuilder.RenameColumn(
                name: "StatusDescription",
                table: "Status",
                newName: "statusDescription");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Status",
                newName: "statusId");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Services",
                newName: "serviceName");

            migrationBuilder.RenameColumn(
                name: "ServiceDescription",
                table: "Services",
                newName: "serviceDescription");

            migrationBuilder.RenameColumn(
                name: "ServiceCommission",
                table: "Services",
                newName: "serviceCommission");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Services",
                newName: "professionalId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Services",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "serviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ProfessionalId",
                table: "Services",
                newName: "IX_Services_professionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                newName: "IX_Services_categoryId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Reservations",
                newName: "statusId");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "Reservations",
                newName: "startHour");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservations",
                newName: "reservationDate");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Reservations",
                newName: "professionalId");

            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "Reservations",
                newName: "endHour");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "reservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations",
                newName: "IX_Reservations_statusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ProfessionalId",
                table: "Reservations",
                newName: "IX_Reservations_professionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_customerId");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Professionals",
                newName: "streetName");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Professionals",
                newName: "postCode");

            migrationBuilder.RenameColumn(
                name: "PlotNumber",
                table: "Professionals",
                newName: "plotNumber");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Professionals",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Professionals",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Professionals",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "GeoCoords",
                table: "Professionals",
                newName: "geoCoords");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Professionals",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Professionals",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Professionals",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Professionals",
                newName: "professionalId");

            migrationBuilder.RenameColumn(
                name: "TimeSlot",
                table: "Plannings",
                newName: "timeSlot");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "Plannings",
                newName: "startHour");

            migrationBuilder.RenameColumn(
                name: "StartBreakTime",
                table: "Plannings",
                newName: "startBreakTime");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Plannings",
                newName: "professionalId");

            migrationBuilder.RenameColumn(
                name: "PlaningDate",
                table: "Plannings",
                newName: "planingDate");

            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "Plannings",
                newName: "endHour");

            migrationBuilder.RenameColumn(
                name: "EndBreakTime",
                table: "Plannings",
                newName: "endBreakTime");

            migrationBuilder.RenameColumn(
                name: "PlaningId",
                table: "Plannings",
                newName: "planingId");

            migrationBuilder.RenameIndex(
                name: "IX_Plannings_ProfessionalId",
                table: "Plannings",
                newName: "IX_Plannings_professionalId");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Invoices",
                newName: "professionalId");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "invoiceDate");

            migrationBuilder.RenameColumn(
                name: "InvoiceAmountTotal",
                table: "Invoices",
                newName: "invoiceAmountTotal");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Invoices",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Invoices",
                newName: "invoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ProfessionalId",
                table: "Invoices",
                newName: "IX_Invoices_professionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                newName: "IX_Invoices_customerId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "InvoiceLines",
                newName: "reservationId");

            migrationBuilder.RenameColumn(
                name: "PreCommission",
                table: "InvoiceLines",
                newName: "preCommission");

            migrationBuilder.RenameColumn(
                name: "PourcentCommission",
                table: "InvoiceLines",
                newName: "pourcentCommission");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceLines",
                newName: "invoiceId");

            migrationBuilder.RenameColumn(
                name: "HourPrice",
                table: "InvoiceLines",
                newName: "hourPrice");

            migrationBuilder.RenameColumn(
                name: "HourCount",
                table: "InvoiceLines",
                newName: "hourCount");

            migrationBuilder.RenameColumn(
                name: "CommissionTotal",
                table: "InvoiceLines",
                newName: "commissionTotal");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "InvoiceLines",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "InvoicelineId",
                table: "InvoiceLines",
                newName: "invoicelineId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_ReservationId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_reservationId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_invoiceId");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Customers",
                newName: "streetName");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Customers",
                newName: "postCode");

            migrationBuilder.RenameColumn(
                name: "PlotNumber",
                table: "Customers",
                newName: "plotNumber");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Customers",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "GeoCoords",
                table: "Customers",
                newName: "geoCoords");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "categoryDescription");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "categoryId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_categoryName",
                table: "Categories",
                column: "categoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Invoices_invoiceId",
                table: "InvoiceLines",
                column: "invoiceId",
                principalTable: "Invoices",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Reservations_reservationId",
                table: "InvoiceLines",
                column: "reservationId",
                principalTable: "Reservations",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_customerId",
                table: "Invoices",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Professionals_professionalId",
                table: "Invoices",
                column: "professionalId",
                principalTable: "Professionals",
                principalColumn: "professionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plannings_Professionals_professionalId",
                table: "Plannings",
                column: "professionalId",
                principalTable: "Professionals",
                principalColumn: "professionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_customerId",
                table: "Reservations",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Professionals_professionalId",
                table: "Reservations",
                column: "professionalId",
                principalTable: "Professionals",
                principalColumn: "professionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Status_statusId",
                table: "Reservations",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "statusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_categoryId",
                table: "Services",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Professionals_professionalId",
                table: "Services",
                column: "professionalId",
                principalTable: "Professionals",
                principalColumn: "professionalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_invoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Reservations_reservationId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_customerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Professionals_professionalId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_Professionals_professionalId",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_customerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Professionals_professionalId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Status_statusId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_categoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Professionals_professionalId",
                table: "Services");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_categoryName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "statusName",
                table: "Status",
                newName: "StatusName");

            migrationBuilder.RenameColumn(
                name: "statusDescription",
                table: "Status",
                newName: "StatusDescription");

            migrationBuilder.RenameColumn(
                name: "statusId",
                table: "Status",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "serviceName",
                table: "Services",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "serviceDescription",
                table: "Services",
                newName: "ServiceDescription");

            migrationBuilder.RenameColumn(
                name: "serviceCommission",
                table: "Services",
                newName: "ServiceCommission");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "Services",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Services",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "Services",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_professionalId",
                table: "Services",
                newName: "IX_Services_ProfessionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_categoryId",
                table: "Services",
                newName: "IX_Services_CategoryId");

            migrationBuilder.RenameColumn(
                name: "statusId",
                table: "Reservations",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "startHour",
                table: "Reservations",
                newName: "StartHour");

            migrationBuilder.RenameColumn(
                name: "reservationDate",
                table: "Reservations",
                newName: "ReservationDate");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "Reservations",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "endHour",
                table: "Reservations",
                newName: "EndHour");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "reservationId",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_statusId",
                table: "Reservations",
                newName: "IX_Reservations_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_professionalId",
                table: "Reservations",
                newName: "IX_Reservations_ProfessionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_customerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.RenameColumn(
                name: "streetName",
                table: "Professionals",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "postCode",
                table: "Professionals",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "plotNumber",
                table: "Professionals",
                newName: "PlotNumber");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Professionals",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Professionals",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Professionals",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "geoCoords",
                table: "Professionals",
                newName: "GeoCoords");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Professionals",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Professionals",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Professionals",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "Professionals",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "timeSlot",
                table: "Plannings",
                newName: "TimeSlot");

            migrationBuilder.RenameColumn(
                name: "startHour",
                table: "Plannings",
                newName: "StartHour");

            migrationBuilder.RenameColumn(
                name: "startBreakTime",
                table: "Plannings",
                newName: "StartBreakTime");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "Plannings",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "planingDate",
                table: "Plannings",
                newName: "PlaningDate");

            migrationBuilder.RenameColumn(
                name: "endHour",
                table: "Plannings",
                newName: "EndHour");

            migrationBuilder.RenameColumn(
                name: "endBreakTime",
                table: "Plannings",
                newName: "EndBreakTime");

            migrationBuilder.RenameColumn(
                name: "planingId",
                table: "Plannings",
                newName: "PlaningId");

            migrationBuilder.RenameIndex(
                name: "IX_Plannings_professionalId",
                table: "Plannings",
                newName: "IX_Plannings_ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "Invoices",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "invoiceDate",
                table: "Invoices",
                newName: "InvoiceDate");

            migrationBuilder.RenameColumn(
                name: "invoiceAmountTotal",
                table: "Invoices",
                newName: "InvoiceAmountTotal");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Invoices",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "invoiceId",
                table: "Invoices",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_professionalId",
                table: "Invoices",
                newName: "IX_Invoices_ProfessionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_customerId",
                table: "Invoices",
                newName: "IX_Invoices_CustomerId");

            migrationBuilder.RenameColumn(
                name: "reservationId",
                table: "InvoiceLines",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "preCommission",
                table: "InvoiceLines",
                newName: "PreCommission");

            migrationBuilder.RenameColumn(
                name: "pourcentCommission",
                table: "InvoiceLines",
                newName: "PourcentCommission");

            migrationBuilder.RenameColumn(
                name: "invoiceId",
                table: "InvoiceLines",
                newName: "InvoiceId");

            migrationBuilder.RenameColumn(
                name: "hourPrice",
                table: "InvoiceLines",
                newName: "HourPrice");

            migrationBuilder.RenameColumn(
                name: "hourCount",
                table: "InvoiceLines",
                newName: "HourCount");

            migrationBuilder.RenameColumn(
                name: "commissionTotal",
                table: "InvoiceLines",
                newName: "CommissionTotal");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "InvoiceLines",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "invoicelineId",
                table: "InvoiceLines",
                newName: "InvoicelineId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_reservationId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_invoiceId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_InvoiceId");

            migrationBuilder.RenameColumn(
                name: "streetName",
                table: "Customers",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "postCode",
                table: "Customers",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "plotNumber",
                table: "Customers",
                newName: "PlotNumber");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Customers",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "geoCoords",
                table: "Customers",
                newName: "GeoCoords");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Customers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "categoryDescription",
                table: "Categories",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName");

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
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Professionals_ProfessionalId",
                table: "Reservations",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Status_StatusId",
                table: "Reservations",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Professionals_ProfessionalId",
                table: "Services",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
