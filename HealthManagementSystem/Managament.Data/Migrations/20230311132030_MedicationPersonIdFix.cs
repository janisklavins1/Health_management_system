using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedicationPersonIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPersons_Medications_MedicationId",
                table: "MedicationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPersons_Persons_PersonId",
                table: "MedicationPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationPersons",
                table: "MedicationPersons");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPersons_MedicationId",
                table: "MedicationPersons");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPersons_PersonId",
                table: "MedicationPersons");

            migrationBuilder.AddColumn<int>(
                name: "MedicationPersonId",
                table: "MedicationPersons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationPersons",
                table: "MedicationPersons",
                column: "MedicationPersonId");

            migrationBuilder.CreateTable(
                name: "MedicationPerson",
                columns: table => new
                {
                    MedicationsMedicationId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPerson", x => new { x.MedicationsMedicationId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_MedicationPerson_Medications_MedicationsMedicationId",
                        column: x => x.MedicationsMedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPersons_MedicationId",
                table: "MedicationPersons",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPersons_PersonId",
                table: "MedicationPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPerson_PersonsPersonId",
                table: "MedicationPerson",
                column: "PersonsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPersons_Medications_MedicationId",
                table: "MedicationPersons",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "MedicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPersons_Persons_PersonId",
                table: "MedicationPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPersons_Medications_MedicationId",
                table: "MedicationPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPersons_Persons_PersonId",
                table: "MedicationPersons");

            migrationBuilder.DropTable(
                name: "MedicationPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationPersons",
                table: "MedicationPersons");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPersons_MedicationId",
                table: "MedicationPersons");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPersons_PersonId",
                table: "MedicationPersons");

            migrationBuilder.DropColumn(
                name: "MedicationPersonId",
                table: "MedicationPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationPersons",
                table: "MedicationPersons",
                columns: new[] { "MedicationId", "PersonId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPersons_Medications_MedicationId",
                table: "MedicationPersons",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPersons_Persons_PersonId",
                table: "MedicationPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }
    }
}
