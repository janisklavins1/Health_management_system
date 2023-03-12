using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class IllnessPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IllnessesPersons_Illnesses_IllnessId",
                table: "IllnessesPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_IllnessesPersons_Persons_PersonId",
                table: "IllnessesPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IllnessesPersons",
                table: "IllnessesPersons");

            migrationBuilder.DropIndex(
                name: "IX_IllnessesPersons_IllnessId",
                table: "IllnessesPersons");

            migrationBuilder.DropIndex(
                name: "IX_IllnessesPersons_PersonId",
                table: "IllnessesPersons");

            migrationBuilder.AddColumn<int>(
                name: "IllnessPersonId",
                table: "IllnessesPersons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IllnessesPersons",
                table: "IllnessesPersons",
                column: "IllnessPersonId");

            migrationBuilder.CreateTable(
                name: "IllnessPerson",
                columns: table => new
                {
                    IllnessesIllnessId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessPerson", x => new { x.IllnessesIllnessId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_IllnessPerson_Illnesses_IllnessesIllnessId",
                        column: x => x.IllnessesIllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllnessPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IllnessesPersons_IllnessId",
                table: "IllnessesPersons",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_IllnessesPersons_PersonId",
                table: "IllnessesPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_IllnessPerson_PersonsPersonId",
                table: "IllnessPerson",
                column: "PersonsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessesPersons_Illnesses_IllnessId",
                table: "IllnessesPersons",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "IllnessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessesPersons_Persons_PersonId",
                table: "IllnessesPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IllnessesPersons_Illnesses_IllnessId",
                table: "IllnessesPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_IllnessesPersons_Persons_PersonId",
                table: "IllnessesPersons");

            migrationBuilder.DropTable(
                name: "IllnessPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IllnessesPersons",
                table: "IllnessesPersons");

            migrationBuilder.DropIndex(
                name: "IX_IllnessesPersons_IllnessId",
                table: "IllnessesPersons");

            migrationBuilder.DropIndex(
                name: "IX_IllnessesPersons_PersonId",
                table: "IllnessesPersons");

            migrationBuilder.DropColumn(
                name: "IllnessPersonId",
                table: "IllnessesPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IllnessesPersons",
                table: "IllnessesPersons",
                columns: new[] { "IllnessId", "PersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_IllnessesPersons_IllnessId",
                table: "IllnessesPersons",
                column: "IllnessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IllnessesPersons_PersonId",
                table: "IllnessesPersons",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessesPersons_Illnesses_IllnessId",
                table: "IllnessesPersons",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "IllnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_IllnessesPersons_Persons_PersonId",
                table: "IllnessesPersons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }
    }
}
