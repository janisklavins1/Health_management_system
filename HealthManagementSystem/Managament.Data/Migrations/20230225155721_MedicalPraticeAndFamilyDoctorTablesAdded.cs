using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedicalPraticeAndFamilyDoctorTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalPractices",
                columns: table => new
                {
                    MedicalPracticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPractices", x => x.MedicalPracticeId);
                    table.ForeignKey(
                        name: "FK_MedicalPractices_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalPractices_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDoctors",
                columns: table => new
                {
                    FamilyDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalPracticeId = table.Column<int>(type: "int", nullable: false),
                    PlaceOfEducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDoctors", x => x.FamilyDoctorId);
                    table.ForeignKey(
                        name: "FK_FamilyDoctors_MedicalPractices_MedicalPracticeId",
                        column: x => x.MedicalPracticeId,
                        principalTable: "MedicalPractices",
                        principalColumn: "MedicalPracticeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctors_MedicalPracticeId",
                table: "FamilyDoctors",
                column: "MedicalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractices_AddressId",
                table: "MedicalPractices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractices_PhoneNumberId",
                table: "MedicalPractices",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Addresses_AddressId",
                table: "Addresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Addresses_AddressId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "FamilyDoctors");

            migrationBuilder.DropTable(
                name: "MedicalPractices");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Addresses");
        }
    }
}
