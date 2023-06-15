using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedMessageToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                columns: new[] { "Message_Date", "Type" },
                values: new object[] { new DateTime(2023, 6, 15, 16, 5, 16, 169, DateTimeKind.Local).AddTicks(7649), 1 });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 15, 16, 5, 16, 169, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                columns: new[] { "Message_Date", "Type" },
                values: new object[] { new DateTime(2023, 6, 15, 16, 5, 16, 169, DateTimeKind.Local).AddTicks(7706), 1 });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 15, 16, 5, 16, 169, DateTimeKind.Local).AddTicks(7708));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                columns: new[] { "Message_Date", "Type" },
                values: new object[] { new DateTime(2023, 6, 15, 14, 13, 51, 282, DateTimeKind.Local).AddTicks(7214), 0 });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 15, 14, 13, 51, 282, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                columns: new[] { "Message_Date", "Type" },
                values: new object[] { new DateTime(2023, 6, 15, 14, 13, 51, 282, DateTimeKind.Local).AddTicks(7269), 0 });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 15, 14, 13, 51, 282, DateTimeKind.Local).AddTicks(7270));
        }
    }
}
