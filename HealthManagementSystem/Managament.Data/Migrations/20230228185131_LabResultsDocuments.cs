using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class LabResultsDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "LabResults",
                columns: table => new
                {
                    LabResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResults", x => x.LabResultId);
                    table.ForeignKey(
                        name: "FK_LabResults_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabResultStatuses",
                columns: table => new
                {
                    LabResultStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResultStatuses", x => x.LabResultStatusId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLabResult",
                columns: table => new
                {
                    DocumentsDocumentId = table.Column<int>(type: "int", nullable: false),
                    LabResultsLabResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLabResult", x => new { x.DocumentsDocumentId, x.LabResultsLabResultId });
                    table.ForeignKey(
                        name: "FK_DocumentLabResult_Documents_DocumentsDocumentId",
                        column: x => x.DocumentsDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentLabResult_LabResults_LabResultsLabResultId",
                        column: x => x.LabResultsLabResultId,
                        principalTable: "LabResults",
                        principalColumn: "LabResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabResultStatusLabResults",
                columns: table => new
                {
                    LabResultId = table.Column<int>(type: "int", nullable: false),
                    LabResultStatusId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResultStatusLabResults", x => new { x.LabResultId, x.LabResultStatusId });
                    table.ForeignKey(
                        name: "FK_LabResultStatusLabResults_LabResultStatuses_LabResultStatusId",
                        column: x => x.LabResultStatusId,
                        principalTable: "LabResultStatuses",
                        principalColumn: "LabResultStatusId");
                    table.ForeignKey(
                        name: "FK_LabResultStatusLabResults_LabResults_LabResultId",
                        column: x => x.LabResultId,
                        principalTable: "LabResults",
                        principalColumn: "LabResultId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLabResult_LabResultsLabResultId",
                table: "DocumentLabResult",
                column: "LabResultsLabResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_PersonId",
                table: "LabResults",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResultStatusLabResults_LabResultId",
                table: "LabResultStatusLabResults",
                column: "LabResultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabResultStatusLabResults_LabResultStatusId",
                table: "LabResultStatusLabResults",
                column: "LabResultStatusId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentLabResult");

            migrationBuilder.DropTable(
                name: "LabResultStatusLabResults");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LabResultStatuses");

            migrationBuilder.DropTable(
                name: "LabResults");
        }
    }
}
