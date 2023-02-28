using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class Vaccinations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPerson_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPerson_Persons_PersonId",
                table: "VaccinationPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPerson_Persons_PersonsPersonId",
                table: "VaccinationPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPerson_Vaccination_VaccinationId",
                table: "VaccinationPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationPerson",
                table: "VaccinationPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccination",
                table: "Vaccination");

            migrationBuilder.DropColumn(
                name: "PersonsPersonId",
                table: "VaccinationPerson");

            migrationBuilder.RenameTable(
                name: "VaccinationPerson",
                newName: "VaccinationPersons");

            migrationBuilder.RenameTable(
                name: "Vaccination",
                newName: "Vaccinations");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPerson_VaccinationId",
                table: "VaccinationPersons",
                newName: "IX_VaccinationPersons_VaccinationId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPerson_PersonId",
                table: "VaccinationPersons",
                newName: "IX_VaccinationPersons_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPerson_MedicalPracticeId",
                table: "VaccinationPersons",
                newName: "IX_VaccinationPersons_MedicalPracticeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons",
                columns: new[] { "PersonId", "VaccinationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccinations",
                table: "Vaccinations",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPersons",
                column: "MedicalPracticeId",
                principalTable: "MedicalPractices",
                principalColumn: "MedicalPracticeId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Persons_PersonId",
                table: "VaccinationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_Vaccinations_VaccinationId",
                table: "VaccinationPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccinations",
                table: "Vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons");

            migrationBuilder.RenameTable(
                name: "Vaccinations",
                newName: "Vaccination");

            migrationBuilder.RenameTable(
                name: "VaccinationPersons",
                newName: "VaccinationPerson");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPersons_VaccinationId",
                table: "VaccinationPerson",
                newName: "IX_VaccinationPerson_VaccinationId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPersons_PersonId",
                table: "VaccinationPerson",
                newName: "IX_VaccinationPerson_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationPersons_MedicalPracticeId",
                table: "VaccinationPerson",
                newName: "IX_VaccinationPerson_MedicalPracticeId");

            migrationBuilder.AddColumn<int>(
                name: "PersonsPersonId",
                table: "VaccinationPerson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccination",
                table: "Vaccination",
                column: "VaccinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationPerson",
                table: "VaccinationPerson",
                columns: new[] { "PersonsPersonId", "VaccinationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPerson_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPerson",
                column: "MedicalPracticeId",
                principalTable: "MedicalPractices",
                principalColumn: "MedicalPracticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPerson_Persons_PersonId",
                table: "VaccinationPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPerson_Persons_PersonsPersonId",
                table: "VaccinationPerson",
                column: "PersonsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPerson_Vaccination_VaccinationId",
                table: "VaccinationPerson",
                column: "VaccinationId",
                principalTable: "Vaccination",
                principalColumn: "VaccinationId");
        }
    }
}
