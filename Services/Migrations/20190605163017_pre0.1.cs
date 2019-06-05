using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Maintenance",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Maintenance",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
