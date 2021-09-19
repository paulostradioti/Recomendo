using Microsoft.EntityFrameworkCore.Migrations;

namespace Recomendo.Website.Migrations
{
    public partial class ReviewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Movies");
        }
    }
}
