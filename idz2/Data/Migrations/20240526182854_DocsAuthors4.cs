using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idz2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocsAuthors4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AuthorsAuthorName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AuthorsAuthorName",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuthorName",
                table: "Documents",
                column: "AuthorName");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents",
                column: "AuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorName",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AuthorName",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AuthorsAuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuthorsAuthorName",
                table: "Documents",
                column: "AuthorsAuthorName");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents",
                column: "AuthorsAuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
