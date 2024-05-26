using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idz2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Staff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefStaffRoles",
                columns: table => new
                {
                    StaffRoleCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefStaffRoles", x => x.StaffRoleCode);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "StaffInProcesses",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StaffRoleCode = table.Column<int>(type: "int", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInProcesses", x => new { x.DocumentId, x.ProcessId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_StaffInProcesses_DocumentsProcesses_DocumentId_ProcessId",
                        columns: x => new { x.DocumentId, x.ProcessId },
                        principalTable: "DocumentsProcesses",
                        principalColumns: new[] { "DocumentId", "ProcessId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffInProcesses_RefStaffRoles_StaffRoleCode",
                        column: x => x.StaffRoleCode,
                        principalTable: "RefStaffRoles",
                        principalColumn: "StaffRoleCode");
                    table.ForeignKey(
                        name: "FK_StaffInProcesses_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffInProcesses_StaffId",
                table: "StaffInProcesses",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInProcesses_StaffRoleCode",
                table: "StaffInProcesses",
                column: "StaffRoleCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffInProcesses");

            migrationBuilder.DropTable(
                name: "RefStaffRoles");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
