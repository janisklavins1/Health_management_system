using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class FamilyDoctorsPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyDoctorPerson",
                columns: table => new
                {
                    FamilyDoctorId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDoctorPerson", x => new { x.FamilyDoctorId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_FamilyDoctorPerson_FamilyDoctors_FamilyDoctorId",
                        column: x => x.FamilyDoctorId,
                        principalTable: "FamilyDoctors",
                        principalColumn: "FamilyDoctorId");
                    table.ForeignKey(
                        name: "FK_FamilyDoctorPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_FamilyDoctorPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorPerson_FamilyDoctorId",
                table: "FamilyDoctorPerson",
                column: "FamilyDoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorPerson_PersonId",
                table: "FamilyDoctorPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorPerson_PersonsPersonId",
                table: "FamilyDoctorPerson",
                column: "PersonsPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDoctorPerson");
        }
    }
}
