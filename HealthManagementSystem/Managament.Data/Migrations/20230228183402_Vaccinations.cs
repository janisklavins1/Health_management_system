using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class Vaccinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccination",
                columns: table => new
                {
                    VaccinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.VaccinationId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationPerson",
                columns: table => new
                {
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MedicalPracticeId = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationPerson", x => new { x.PersonsPersonId, x.VaccinationId });
                    table.ForeignKey(
                        name: "FK_VaccinationPerson_MedicalPractices_MedicalPracticeId",
                        column: x => x.MedicalPracticeId,
                        principalTable: "MedicalPractices",
                        principalColumn: "MedicalPracticeId");
                    table.ForeignKey(
                        name: "FK_VaccinationPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_VaccinationPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationPerson_Vaccination_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccination",
                        principalColumn: "VaccinationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPerson_MedicalPracticeId",
                table: "VaccinationPerson",
                column: "MedicalPracticeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPerson_PersonId",
                table: "VaccinationPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPerson_VaccinationId",
                table: "VaccinationPerson",
                column: "VaccinationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationPerson");

            migrationBuilder.DropTable(
                name: "Vaccination");
        }
    }
}
