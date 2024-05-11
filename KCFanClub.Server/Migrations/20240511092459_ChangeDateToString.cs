using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Match",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/16", "11:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/18", "11:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/21", "11:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/25", "11:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { "2024/05/30", "11:00 am" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Match",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateOnly(2024, 5, 16), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateOnly(2024, 5, 18), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateOnly(2024, 5, 21), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateOnly(2024, 5, 25), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateOnly(2024, 5, 30), "12:00 am" });
        }
    }
}
