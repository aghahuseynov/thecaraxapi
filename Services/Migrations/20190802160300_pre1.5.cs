using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationSite",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccessToken",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationSite",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationSite",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LocationSite",
                table: "Customers");
        }
    }
}
