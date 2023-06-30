using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductPriceAndUnitInStockInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 1, 12, 840, DateTimeKind.Local).AddTicks(5159));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 20, 42, 3, 9, DateTimeKind.Local).AddTicks(4152));
        }
    }
}
