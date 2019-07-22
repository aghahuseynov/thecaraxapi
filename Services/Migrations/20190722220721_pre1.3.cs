using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BloodGroup",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BloodGroup",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
