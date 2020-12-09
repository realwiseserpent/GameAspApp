using Microsoft.EntityFrameworkCore.Migrations;

namespace GameAspApp.DAL.Migrations
{
    public partial class GenreAndSeriesDescAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Series",
                type: "character varying(2500)",
                maxLength: 2500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genres",
                type: "character varying(2500)",
                maxLength: 2500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genres");
        }
    }
}
