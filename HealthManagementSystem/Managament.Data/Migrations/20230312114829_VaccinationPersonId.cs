using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class VaccinationPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons");

            migrationBuilder.AddColumn<int>(
                name: "VaccinationPersonId",
                table: "VaccinationPersons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons",
                column: "VaccinationPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons");

            migrationBuilder.DropColumn(
                name: "VaccinationPersonId",
                table: "VaccinationPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationPersons",
                table: "VaccinationPersons",
                columns: new[] { "PersonId", "VaccinationId" });
        }
    }
}
