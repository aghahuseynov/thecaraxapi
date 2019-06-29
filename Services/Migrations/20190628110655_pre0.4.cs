using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservation_CarServices_CarSericeId",
                table: "ServicesInReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservation_Companies_CompanyCode",
                table: "ServicesInReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservation_Departments_DepartmentCode",
                table: "ServicesInReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservation_Reservations_ReservationId",
                table: "ServicesInReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicesInReservation",
                table: "ServicesInReservation");

            migrationBuilder.RenameTable(
                name: "ServicesInReservation",
                newName: "ServicesInReservations");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservation_ReservationId",
                table: "ServicesInReservations",
                newName: "IX_ServicesInReservations_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservation_DepartmentCode",
                table: "ServicesInReservations",
                newName: "IX_ServicesInReservations_DepartmentCode");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservation_CompanyCode",
                table: "ServicesInReservations",
                newName: "IX_ServicesInReservations_CompanyCode");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservation_CarSericeId",
                table: "ServicesInReservations",
                newName: "IX_ServicesInReservations_CarSericeId");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicesInReservations",
                table: "ServicesInReservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservations_CarServices_CarSericeId",
                table: "ServicesInReservations",
                column: "CarSericeId",
                principalTable: "CarServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservations_Companies_CompanyCode",
                table: "ServicesInReservations",
                column: "CompanyCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservations_Departments_DepartmentCode",
                table: "ServicesInReservations",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservations_Reservations_ReservationId",
                table: "ServicesInReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservations_CarServices_CarSericeId",
                table: "ServicesInReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservations_Companies_CompanyCode",
                table: "ServicesInReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservations_Departments_DepartmentCode",
                table: "ServicesInReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesInReservations_Reservations_ReservationId",
                table: "ServicesInReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicesInReservations",
                table: "ServicesInReservations");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "ServicesInReservations",
                newName: "ServicesInReservation");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservations_ReservationId",
                table: "ServicesInReservation",
                newName: "IX_ServicesInReservation_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservations_DepartmentCode",
                table: "ServicesInReservation",
                newName: "IX_ServicesInReservation_DepartmentCode");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservations_CompanyCode",
                table: "ServicesInReservation",
                newName: "IX_ServicesInReservation_CompanyCode");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesInReservations_CarSericeId",
                table: "ServicesInReservation",
                newName: "IX_ServicesInReservation_CarSericeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicesInReservation",
                table: "ServicesInReservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservation_CarServices_CarSericeId",
                table: "ServicesInReservation",
                column: "CarSericeId",
                principalTable: "CarServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservation_Companies_CompanyCode",
                table: "ServicesInReservation",
                column: "CompanyCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservation_Departments_DepartmentCode",
                table: "ServicesInReservation",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesInReservation_Reservations_ReservationId",
                table: "ServicesInReservation",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
