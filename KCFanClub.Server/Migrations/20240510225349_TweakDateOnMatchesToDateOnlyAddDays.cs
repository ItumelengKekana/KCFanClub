using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    /// <inheritdoc />
    public partial class TweakDateOnMatchesToDateOnlyAddDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 5, 18));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 5, 21));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 5, 25));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 5, 30));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
