using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idz2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocsAuthors2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorName);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorsAuthorName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentsId);
                    table.ForeignKey(
                        name: "FK_Documents_Authors_AuthorsAuthorName",
                        column: x => x.AuthorsAuthorName,
                        principalTable: "Authors",
                        principalColumn: "AuthorName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuthorsAuthorName",
                table: "Documents",
                column: "AuthorsAuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
