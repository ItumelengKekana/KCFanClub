using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class TweakTimeOnMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(4995), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 18, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5062), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 20, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5069), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 26, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5072), "12:00 am" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7096), "hh:00 tt" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 18, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7166), "hh:00 tt" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 20, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7232), "hh:00 tt" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 26, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7236), "hh:00 tt" });
        }
    }
}
