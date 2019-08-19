using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountyId",
                table: "Customers",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Counties_CountyId",
                table: "Customers",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Counties_CountyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Customers");
        }
    }
}
