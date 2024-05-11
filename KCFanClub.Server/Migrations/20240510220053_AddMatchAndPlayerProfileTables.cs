using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchAndPlayerProfileTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Opponent = table.Column<string>(type: "longtext", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Time = table.Column<string>(type: "longtext", nullable: false),
                    Venue = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Position = table.Column<string>(type: "longtext", nullable: false),
                    Nationality = table.Column<string>(type: "longtext", nullable: false),
                    Bio = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfile", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "Date", "Opponent", "Time", "Venue" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5342), "Orlando Pirates", "hh:00 tt", "Orlando Stadium" },
                    { 2, new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5399), "Golden Arrows", "hh:00 tt", "Lamontville Stadium" },
                    { 3, new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5403), "Bloemfontein Celtics", "hh:00 tt", "Bloemfontein Stadium" },
                    { 4, new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5407), "Mamelodi Sundowns", "hh:00 tt", "HM Pitje Stadium" },
                    { 5, new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5410), "Moroka Swallows", "hh:00 tt", "Moroka Stadium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "PlayerProfile");
        }
    }
}
