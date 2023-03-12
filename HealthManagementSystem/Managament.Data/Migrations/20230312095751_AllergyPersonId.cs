using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class AllergyPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergiesPerson_Allergies_AllergyId",
                table: "AllergiesPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergiesPerson_Persons_PersonId",
                table: "AllergiesPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergiesPerson",
                table: "AllergiesPerson");

            migrationBuilder.DropIndex(
                name: "IX_AllergiesPerson_AllergyId",
                table: "AllergiesPerson");

            migrationBuilder.DropIndex(
                name: "IX_AllergiesPerson_PersonId",
                table: "AllergiesPerson");

            migrationBuilder.AddColumn<int>(
                name: "AllergyPersonId",
                table: "AllergiesPerson",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergiesPerson",
                table: "AllergiesPerson",
                column: "AllergyPersonId");

            migrationBuilder.CreateTable(
                name: "AllergyPerson",
                columns: table => new
                {
                    AllergiesAllergyId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyPerson", x => new { x.AllergiesAllergyId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_AllergyPerson_Allergies_AllergiesAllergyId",
                        column: x => x.AllergiesAllergyId,
                        principalTable: "Allergies",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_AllergyId",
                table: "AllergiesPerson",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_PersonId",
                table: "AllergiesPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergyPerson_PersonsPersonId",
                table: "AllergyPerson",
                column: "PersonsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergiesPerson_Allergies_AllergyId",
                table: "AllergiesPerson",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "AllergyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergiesPerson_Persons_PersonId",
                table: "AllergiesPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergiesPerson_Allergies_AllergyId",
                table: "AllergiesPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergiesPerson_Persons_PersonId",
                table: "AllergiesPerson");

            migrationBuilder.DropTable(
                name: "AllergyPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergiesPerson",
                table: "AllergiesPerson");

            migrationBuilder.DropIndex(
                name: "IX_AllergiesPerson_AllergyId",
                table: "AllergiesPerson");

            migrationBuilder.DropIndex(
                name: "IX_AllergiesPerson_PersonId",
                table: "AllergiesPerson");

            migrationBuilder.DropColumn(
                name: "AllergyPersonId",
                table: "AllergiesPerson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergiesPerson",
                table: "AllergiesPerson",
                columns: new[] { "AllergyId", "PersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_AllergyId",
                table: "AllergiesPerson",
                column: "AllergyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_PersonId",
                table: "AllergiesPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergiesPerson_Allergies_AllergyId",
                table: "AllergiesPerson",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "AllergyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergiesPerson_Persons_PersonId",
                table: "AllergiesPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }
    }
}
