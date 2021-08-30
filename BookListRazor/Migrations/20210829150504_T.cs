using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class T : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //  name: "FK_Book_Genre_GenreId",
            //  table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_GenreId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
