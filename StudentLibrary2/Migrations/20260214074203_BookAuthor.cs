using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentLibrary2.Migrations
{
    /// <inheritdoc />
    public partial class BookAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_StudentId",
                table: "Books",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Students_StudentId",
                table: "Books",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Students_StudentId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_StudentId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
