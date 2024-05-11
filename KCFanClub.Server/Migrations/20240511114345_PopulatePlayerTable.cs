using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class PopulatePlayerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "PlayerProfile",
                columns: new[] { "Id", "Bio", "Name", "Nationality", "Position" },
                values: new object[,]
                {
                    { 1, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Itumeleng Khune", "South African", "Goalkeeper" },
                    { 2, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Jasond González", "Colombian", "Forward" },
                    { 3, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Ashley Du Preez", "South African", "Forward" },
                    { 4, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Mfundo Vilakazi", "South African", "Midfielder" },
                    { 5, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium", "Edson Castillo", "Venezuelan", "Midfielder" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlayerProfile",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "11:00 am");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "11:00 am");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "11:00 am");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "11:00 am");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "11:00 am");
        }
    }
}
