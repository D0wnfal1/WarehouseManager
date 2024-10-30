using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "OrderDate",
                value: new DateTime(2024, 10, 27, 17, 4, 15, 510, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 17, 4, 15, 510, DateTimeKind.Utc).AddTicks(3394));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "OrderDate",
                value: new DateTime(2024, 10, 27, 14, 32, 52, 706, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 14, 32, 52, 706, DateTimeKind.Utc).AddTicks(4054));
        }
    }
}
