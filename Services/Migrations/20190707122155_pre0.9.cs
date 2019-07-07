using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingClasses",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfFather",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfMother",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingClasses",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NameOfFather",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NameOfMother",
                table: "Customers");
        }
    }
}
