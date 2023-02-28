using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFamilyDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDoctorsPersons");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "MedicalServices");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "FamilyDoctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctors_PersonId",
                table: "FamilyDoctors",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDoctors_Persons_PersonId",
                table: "FamilyDoctors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDoctors_Persons_PersonId",
                table: "FamilyDoctors");

            migrationBuilder.DropIndex(
                name: "IX_FamilyDoctors_PersonId",
                table: "FamilyDoctors");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "FamilyDoctors");

            migrationBuilder.CreateTable(
                name: "FamilyDoctorsPersons",
                columns: table => new
                {
                    FamilyDoctorId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDoctorsPersons", x => new { x.FamilyDoctorId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_FamilyDoctorsPersons_FamilyDoctors_FamilyDoctorId",
                        column: x => x.FamilyDoctorId,
                        principalTable: "FamilyDoctors",
                        principalColumn: "FamilyDoctorId");
                    table.ForeignKey(
                        name: "FK_FamilyDoctorsPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalServices",
                columns: table => new
                {
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServices", x => x.MedicalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.MedicalHistoryId);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_MedicalServices_MedicalServiceId",
                        column: x => x.MedicalServiceId,
                        principalTable: "MedicalServices",
                        principalColumn: "MedicalServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorsPersons_FamilyDoctorId",
                table: "FamilyDoctorsPersons",
                column: "FamilyDoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorsPersons_PersonId",
                table: "FamilyDoctorsPersons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_MedicalServiceId",
                table: "MedicalHistories",
                column: "MedicalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PersonId",
                table: "MedicalHistories",
                column: "PersonId");
        }
    }
}
