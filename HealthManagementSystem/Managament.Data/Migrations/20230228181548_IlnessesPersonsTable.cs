using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class IlnessesPersonsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    IllnessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.IllnessId);
                });

            migrationBuilder.CreateTable(
                name: "IllnessesPersons",
                columns: table => new
                {
                    IllnessId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DateDiscovered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prohibitions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessesPersons", x => new { x.IllnessId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_IllnessesPersons_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessId");
                    table.ForeignKey(
                        name: "FK_IllnessesPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IllnessesPersons");

            migrationBuilder.DropTable(
                name: "Illnesses");
        }
    }
}
