using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idz2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocsAuthors3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorsAuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents",
                column: "AuthorsAuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorsAuthorName",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Authors_AuthorsAuthorName",
                table: "Documents",
                column: "AuthorsAuthorName",
                principalTable: "Authors",
                principalColumn: "AuthorName");
        }
    }
}
