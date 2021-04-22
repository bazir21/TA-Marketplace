using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Migrations
{
    public partial class CreateIdentityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministratorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TCDEmail = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructorModelList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorModelList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModuleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ModuleCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    AcademicYear = table.Column<short>(type: "smallint", nullable: false),
                    Semester = table.Column<short>(type: "smallint", nullable: false),
                    TotalHoursAvailable = table.Column<int>(type: "int", nullable: false),
                    MaxHoursPerInstructor = table.Column<short>(type: "smallint", nullable: false),
                    MinHoursPerInstructor = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TCDEmail = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministratorModelModuleModel",
                columns: table => new
                {
                    LecturersId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorModelModuleModel", x => new { x.LecturersId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_AdministratorModelModuleModel_AdministratorModel_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "AdministratorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministratorModelModuleModel_modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModuleModelId = table.Column<int>(type: "int", nullable: false),
                    InstructorBidded = table.Column<string>(type: "longtext", nullable: false),
                    HoursBid = table.Column<short>(type: "smallint", nullable: false),
                    Accepted = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidModel_modules_ModuleModelId",
                        column: x => x.ModuleModelId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Level = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    TCDEmail = table.Column<string>(type: "longtext", nullable: false),
                    InstructorModelListId = table.Column<int>(type: "int", nullable: true),
                    ModuleModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorModel_InstructorModelList_InstructorModelListId",
                        column: x => x.InstructorModelListId,
                        principalTable: "InstructorModelList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorModel_modules_ModuleModelId",
                        column: x => x.ModuleModelId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorModelModuleModel_ModulesId",
                table: "AdministratorModelModuleModel",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_BidModel_ModuleModelId",
                table: "BidModel",
                column: "ModuleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorModel_InstructorModelListId",
                table: "InstructorModel",
                column: "InstructorModelListId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorModel_ModuleModelId",
                table: "InstructorModel",
                column: "ModuleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorModelModuleModel");

            migrationBuilder.DropTable(
                name: "BidModel");

            migrationBuilder.DropTable(
                name: "InstructorModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "AdministratorModel");

            migrationBuilder.DropTable(
                name: "InstructorModelList");

            migrationBuilder.DropTable(
                name: "modules");
        }
    }
}
