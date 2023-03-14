using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedidforlabResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResultStatusLabResults_LabResultStatuses_LabResultStatusId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropForeignKey(
                name: "FK_LabResultStatusLabResults_LabResults_LabResultId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabResultStatusLabResults",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResultStatusLabResults_LabResultId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResultStatusLabResults_LabResultStatusId",
                table: "LabResultStatusLabResults");

            migrationBuilder.AddColumn<int>(
                name: "LabResultStatusLabResultId",
                table: "LabResultStatusLabResults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabResultStatusLabResults",
                table: "LabResultStatusLabResults",
                column: "LabResultStatusLabResultId");

            migrationBuilder.CreateTable(
                name: "LabResultLabResultStatus",
                columns: table => new
                {
                    LabResultStatusesLabResultStatusId = table.Column<int>(type: "int", nullable: false),
                    LabResultsLabResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResultLabResultStatus", x => new { x.LabResultStatusesLabResultStatusId, x.LabResultsLabResultId });
                    table.ForeignKey(
                        name: "FK_LabResultLabResultStatus_LabResultStatuses_LabResultStatusesLabResultStatusId",
                        column: x => x.LabResultStatusesLabResultStatusId,
                        principalTable: "LabResultStatuses",
                        principalColumn: "LabResultStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabResultLabResultStatus_LabResults_LabResultsLabResultId",
                        column: x => x.LabResultsLabResultId,
                        principalTable: "LabResults",
                        principalColumn: "LabResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabResultStatusLabResults_LabResultId",
                table: "LabResultStatusLabResults",
                column: "LabResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResultStatusLabResults_LabResultStatusId",
                table: "LabResultStatusLabResults",
                column: "LabResultStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResultLabResultStatus_LabResultsLabResultId",
                table: "LabResultLabResultStatus",
                column: "LabResultsLabResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResultStatusLabResults_LabResultStatuses_LabResultStatusId",
                table: "LabResultStatusLabResults",
                column: "LabResultStatusId",
                principalTable: "LabResultStatuses",
                principalColumn: "LabResultStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabResultStatusLabResults_LabResults_LabResultId",
                table: "LabResultStatusLabResults",
                column: "LabResultId",
                principalTable: "LabResults",
                principalColumn: "LabResultId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResultStatusLabResults_LabResultStatuses_LabResultStatusId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropForeignKey(
                name: "FK_LabResultStatusLabResults_LabResults_LabResultId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropTable(
                name: "LabResultLabResultStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabResultStatusLabResults",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResultStatusLabResults_LabResultId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropIndex(
                name: "IX_LabResultStatusLabResults_LabResultStatusId",
                table: "LabResultStatusLabResults");

            migrationBuilder.DropColumn(
                name: "LabResultStatusLabResultId",
                table: "LabResultStatusLabResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabResultStatusLabResults",
                table: "LabResultStatusLabResults",
                columns: new[] { "LabResultId", "LabResultStatusId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_LabResultStatusLabResults_LabResultStatuses_LabResultStatusId",
                table: "LabResultStatusLabResults",
                column: "LabResultStatusId",
                principalTable: "LabResultStatuses",
                principalColumn: "LabResultStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResultStatusLabResults_LabResults_LabResultId",
                table: "LabResultStatusLabResults",
                column: "LabResultId",
                principalTable: "LabResults",
                principalColumn: "LabResultId");
        }
    }
}
