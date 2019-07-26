using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Departments",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Departments",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Departments",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Departments",
                type: "nvarchar(75)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaxNo",
                table: "Departments",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Departments",
                type: "nvarchar(75)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficalEMail",
                table: "Departments",
                type: "nvarchar(75)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Departments",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicSiteUrl",
                table: "Departments",
                type: "nvarchar(75)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxAdministration",
                table: "Departments",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Departments",
                type: "nvarchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "FaxNo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "OfficalEMail",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "PublicSiteUrl",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TaxAdministration",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Departments",
                type: "nvarchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);
        }
    }
}
