using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedmedicalPracticeIdFromVaccinatinoPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationPersons_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPersons");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationPersons_MedicalPracticeId",
                table: "VaccinationPersons");

            migrationBuilder.DropColumn(
                name: "MedicalPracticeId",
                table: "VaccinationPersons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalPracticeId",
                table: "VaccinationPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPersons_MedicalPracticeId",
                table: "VaccinationPersons",
                column: "MedicalPracticeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationPersons_MedicalPractices_MedicalPracticeId",
                table: "VaccinationPersons",
                column: "MedicalPracticeId",
                principalTable: "MedicalPractices",
                principalColumn: "MedicalPracticeId");
        }
    }
}
