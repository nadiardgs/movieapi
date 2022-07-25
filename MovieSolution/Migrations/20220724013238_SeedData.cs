using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSolution.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IdImbd", "Name", "ReleaseDate", "UserScore", "Watched" },
                values: new object[] { 1, "John Wick is on the run after killing a member of the international assassins", 0, "tt6146586", "John Wick", new DateTime(2019, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.9000000000000004, false });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IdImbd", "Name", "ReleaseDate", "UserScore", "Watched" },
                values: new object[] { 2, "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins", 0, "tt4154796", "Avengers: Endgame", new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.4000000000000004, false });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IdImbd", "Name", "ReleaseDate", "UserScore", "Watched" },
                values: new object[] { 3, "The untold story of one twelve-year-old's dream to become the world's greatest supervillain", 1, "tt5113044", "Minions: The Rise of Gru", new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.9000000000000004, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
