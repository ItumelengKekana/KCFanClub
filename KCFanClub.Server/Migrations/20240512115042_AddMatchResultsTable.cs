using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchResultsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HomeTeam = table.Column<string>(type: "longtext", nullable: false),
                    AwayTeam = table.Column<string>(type: "longtext", nullable: false),
                    HomeScore = table.Column<string>(type: "longtext", nullable: false),
                    AwayScore = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: "2024/05/17");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "2024/05/19");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: "2024/05/22");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: "2024/05/26");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: "2024/05/31");

            migrationBuilder.InsertData(
                table: "MatchResults",
                columns: new[] { "Id", "AwayScore", "AwayTeam", "HomeScore", "HomeTeam" },
                values: new object[,]
                {
                    { 1, "0", "Orlando Pirates", "3", "Kaizer Chiefs" },
                    { 2, "2", "Kaizer Chiefs", "1", "Polokwane City" },
                    { 3, "0", "TS Galaxy", "1", "Kaizer Chiefs" },
                    { 4, "3", "AmaZulu", "2", "Kaizer Chiefs" },
                    { 5, "0", "Kaizer Chiefs", "3", "Cape Town City" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: "2024/05/16");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "2024/05/18");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: "2024/05/21");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: "2024/05/25");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: "2024/05/30");
        }
    }
}
