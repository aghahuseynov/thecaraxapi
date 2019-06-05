using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class pre00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VisualId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    VisualId = table.Column<int>(nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DepartmentCode = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServices_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarServices_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthOfDateTime = table.Column<DateTime>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Tc = table.Column<string>(nullable: true),
                    PassportSerialNumber = table.Column<string>(nullable: true),
                    FirstPhone = table.Column<string>(nullable: true),
                    SecondPhone = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    YearOfDrivingLicense = table.Column<int>(nullable: false),
                    SerialNumberOfDrivingLicense = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    InBlackList = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visuals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visuals_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visuals_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    VisualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Visuals_VisualId",
                        column: x => x.VisualId,
                        principalTable: "Visuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VisualId = table.Column<int>(nullable: true),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "binary(64)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "binary(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Visuals_VisualId",
                        column: x => x.VisualId,
                        principalTable: "Visuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Year = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    VisualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandModels_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrandModels_Visuals_VisualId",
                        column: x => x.VisualId,
                        principalTable: "Visuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenGuid = table.Column<Guid>(nullable: false),
                    TokenEndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenGuid);
                    table.ForeignKey(
                        name: "FK_Tokens_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tokens_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokenInfos",
                columns: table => new
                {
                    TokenGuid = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TokenEndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokenInfos", x => x.TokenGuid);
                    table.ForeignKey(
                        name: "FK_UserTokenInfos_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTokenInfos_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTokenInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    BrandModelId = table.Column<int>(nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CaseType = table.Column<int>(nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    GearType = table.Column<int>(nullable: false),
                    Km = table.Column<string>(nullable: true),
                    EngineCapacity = table.Column<string>(nullable: true),
                    NumberOfDoors = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    MinDriverLicense = table.Column<int>(nullable: false),
                    Maintenance = table.Column<bool>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Deposit = table.Column<decimal>(nullable: true),
                    Classes = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    VisualId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CompanyCode = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_BrandModels_BrandModelId",
                        column: x => x.BrandModelId,
                        principalTable: "BrandModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Visuals_VisualId",
                        column: x => x.VisualId,
                        principalTable: "Visuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarInServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: false),
                    CarServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarInServices_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarInServices_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarProperties_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandModels_BrandId",
                table: "BrandModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandModels_VisualId",
                table: "BrandModels",
                column: "VisualId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_VisualId",
                table: "Brands",
                column: "VisualId");

            migrationBuilder.CreateIndex(
                name: "IX_CarInServices_CarId",
                table: "CarInServices",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarInServices_CarServiceId",
                table: "CarInServices",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProperties_CarId",
                table: "CarProperties",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandModelId",
                table: "Cars",
                column: "BrandModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CompanyCode",
                table: "Cars",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DepartmentCode",
                table: "Cars",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VisualId",
                table: "Cars",
                column: "VisualId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_CompanyCode",
                table: "CarServices",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_DepartmentCode",
                table: "CarServices",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyCode",
                table: "Customers",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DepartmentCode",
                table: "Customers",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyCode",
                table: "Departments",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_CompanyCode",
                table: "Tokens",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_DepartmentCode",
                table: "Tokens",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_CompanyCode",
                table: "UserDepartments",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentCode",
                table: "UserDepartments",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserId",
                table: "UserDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyCode",
                table: "Users",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentCode",
                table: "Users",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisualId",
                table: "Users",
                column: "VisualId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenInfos_CompanyCode",
                table: "UserTokenInfos",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenInfos_DepartmentCode",
                table: "UserTokenInfos",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenInfos_UserId",
                table: "UserTokenInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visuals_CompanyCode",
                table: "Visuals",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Visuals_DepartmentCode",
                table: "Visuals",
                column: "DepartmentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarInServices");

            migrationBuilder.DropTable(
                name: "CarProperties");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "UserTokenInfos");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BrandModels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Visuals");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
