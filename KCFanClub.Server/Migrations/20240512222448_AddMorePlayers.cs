using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/18", "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/20", "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/23", "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/27", "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/06/01", "12:00 am" });

            migrationBuilder.InsertData(
                table: "PlayerProfile",
                columns: new[] { "Id", "Bio", "Name", "Nationality", "Position" },
                values: new object[,]
                {
                    { 6, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Edmilson Dove", "Mozambique", "Defender" },
                    { 7, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Thatayaone Ditlhokwe", "Botswana", "Defender" },
                    { 8, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Njabulo Ngcobo", "South African", "Defender" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/17", "04:00 pm" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/19", "04:00 pm" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/22", "04:00 pm" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/26", "04:00 pm" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/31", "04:00 pm" });
        }
    }
}
