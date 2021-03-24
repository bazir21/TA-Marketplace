using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Migrations
{
    public partial class CreateIdentityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
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
                    table.PrimaryKey("PK_Modules", x => x.Id);
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
                        name: "FK_AdministratorModelModuleModel_Administrators_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministratorModelModuleModel_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
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
                    InstructorModelListId = table.Column<int>(type: "int", nullable: true),
                    ModuleModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorModel_Instructors_InstructorModelListId",
                        column: x => x.InstructorModelListId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorModel_Modules_ModuleModelId",
                        column: x => x.ModuleModelId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModuleBiddedId = table.Column<int>(type: "int", nullable: false),
                    InstructorBiddedId = table.Column<int>(type: "int", nullable: true),
                    HoursBid = table.Column<short>(type: "smallint", nullable: false),
                    Accepted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_InstructorModel_InstructorBiddedId",
                        column: x => x.InstructorBiddedId,
                        principalTable: "InstructorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Modules_ModuleBiddedId",
                        column: x => x.ModuleBiddedId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorModelModuleModel_ModulesId",
                table: "AdministratorModelModuleModel",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_InstructorBiddedId",
                table: "Bids",
                column: "InstructorBiddedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ModuleBiddedId",
                table: "Bids",
                column: "ModuleBiddedId");

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
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "InstructorModel");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
