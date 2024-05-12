using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "04:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "04:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "04:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "04:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "04:00 pm");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Comment", "Username" },
                values: new object[,]
                {
                    { 1, "Test", "Test" },
                    { 2, "Sed ut perspiciatis unde omnis iste", "Test1" },
                    { 3, "Sed ut perspiciatis unde omnis iste", "John" },
                    { 4, "Sed ut perspiciatis unde omnis iste", "Jane" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "01:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "01:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "01:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "01:00 pm");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "01:00 pm");
        }
    }
}
