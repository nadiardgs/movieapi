using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSolution.Migrations
{
    public partial class AddInternetScoresToMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaScore",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MetaScore", "Ratings" },
                values: new object[] { "87%", "Internet Movie Database 7.4 / 10 Rotten Tomatoes 89% Metacritic 73/100" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MetaScore", "Ratings" },
                values: new object[] { "91%", "Internet Movie Database 7.8 / 10 Rotten Tomatoes 83%" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MetaScore", "Ratings" },
                values: new object[] { "77%", "Internet Movie Database 6.5 / 10 Rotten Tomatoes 80% Metacritic 70/100" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaScore",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Movies");
        }
    }
}
