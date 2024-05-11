using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class TweakDatesOnMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 18, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7170), "12:00 am" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 5, 22, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 26, 0, 7, 2, 246, DateTimeKind.Local).AddTicks(7236));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5403), "hh:00 tt" });

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 0, 53, 620, DateTimeKind.Local).AddTicks(5410));
        }
    }
}
