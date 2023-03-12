using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class Removedcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Persons_PersonId",
                table: "VaccinationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Vaccinations_VaccinationId",
                table: "VaccinationPersons");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationPersons_PersonId",
                table: "VaccinationPersons");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationPersons_VaccinationId",
                table: "VaccinationPersons");

            migrationBuilder.CreateTable(
                name: "PersonVaccination",
                columns: table => new
                {
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false),
                    VaccinationsVaccinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVaccination", x => new { x.PersonsPersonId, x.VaccinationsVaccinationId });
                    table.ForeignKey(
                        name: "FK_PersonVaccination_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVaccination_Vaccinations_VaccinationsVaccinationId",
                        column: x => x.VaccinationsVaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPersons_PersonId",
                table: "VaccinationPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPersons_VaccinationId",
                table: "VaccinationPersons",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVaccination_VaccinationsVaccinationId",
                table: "PersonVaccination",
                column: "VaccinationsVaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_Persons_PersonId",
                table: "VaccinationPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_Vaccinations_VaccinationId",
                table: "VaccinationPersons",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Persons_PersonId",
                table: "VaccinationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Vaccinations_VaccinationId",
                table: "VaccinationPersons");

            migrationBuilder.DropTable(
                name: "PersonVaccination");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationPersons_PersonId",
                table: "VaccinationPersons");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationPersons_VaccinationId",
                table: "VaccinationPersons");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPersons_PersonId",
                table: "VaccinationPersons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPersons_VaccinationId",
                table: "VaccinationPersons",
                column: "VaccinationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_Persons_PersonId",
                table: "VaccinationPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_Vaccinations_VaccinationId",
                table: "VaccinationPersons",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId");
        }
    }
}
