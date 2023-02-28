using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedicationPersonsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationPersons",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPersons", x => new { x.MedicationId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_MedicationPersons_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId");
                    table.ForeignKey(
                        name: "FK_MedicationPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPersons_MedicationId",
                table: "MedicationPersons",
                column: "MedicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPersons_PersonId",
                table: "MedicationPersons",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationPersons");
        }
    }
}
