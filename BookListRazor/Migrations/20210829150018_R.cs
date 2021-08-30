using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class R : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "GenreId",
           table: "Book");


            migrationBuilder.DropIndex(
                name: "IX_Book_GenreId",
                table: "Book");
        }
    }
}
