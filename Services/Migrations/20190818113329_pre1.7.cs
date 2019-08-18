using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "OldCity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OldCity",
                table: "Customers",
                newName: "City");
        }
    }
}
