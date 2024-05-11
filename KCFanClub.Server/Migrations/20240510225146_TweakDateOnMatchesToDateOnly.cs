using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class TweakDateOnMatchesToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Match",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 5, 16));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 5, 16));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 5, 16));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 5, 16));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 5, 16));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Match",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 16, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 18, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5062));

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
                column: "Date",
                value: new DateTime(2024, 5, 22, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 26, 0, 8, 27, 97, DateTimeKind.Local).AddTicks(5072));
        }
    }
}
