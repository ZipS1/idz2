using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idz2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Processes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "DocumentsId",
                table: "Documents",
                newName: "DocumentId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "BusinessProcesses",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NextProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcesses", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_BusinessProcesses_BusinessProcesses_NextProcessId",
                        column: x => x.NextProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "ProcessId");
                });

            migrationBuilder.CreateTable(
                name: "ProcessOutcomes",
                columns: table => new
                {
                    ProcessOutcomeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessOutcomeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessOutcomes", x => x.ProcessOutcomeCode);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStatus",
                columns: table => new
                {
                    ProcessStatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStatus", x => x.ProcessStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsProcesses",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    ProcessOutcomeCode = table.Column<int>(type: "int", nullable: false),
                    ProcessStatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsProcesses", x => new { x.DocumentId, x.ProcessId });
                    table.ForeignKey(
                        name: "FK_DocumentsProcesses_BusinessProcesses_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsProcesses_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsProcesses_ProcessOutcomes_ProcessOutcomeCode",
                        column: x => x.ProcessOutcomeCode,
                        principalTable: "ProcessOutcomes",
                        principalColumn: "ProcessOutcomeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentsProcesses_ProcessStatus_ProcessStatusCode",
                        column: x => x.ProcessStatusCode,
                        principalTable: "ProcessStatus",
                        principalColumn: "ProcessStatusCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcesses_NextProcessId",
                table: "BusinessProcesses",
                column: "NextProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsProcesses_ProcessId",
                table: "DocumentsProcesses",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsProcesses_ProcessOutcomeCode",
                table: "DocumentsProcesses",
                column: "ProcessOutcomeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsProcesses_ProcessStatusCode",
                table: "DocumentsProcesses",
                column: "ProcessStatusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentsProcesses");

            migrationBuilder.DropTable(
                name: "BusinessProcesses");

            migrationBuilder.DropTable(
                name: "ProcessOutcomes");

            migrationBuilder.DropTable(
                name: "ProcessStatus");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Documents",
                newName: "DocumentsId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
