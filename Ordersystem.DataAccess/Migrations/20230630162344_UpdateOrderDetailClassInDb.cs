using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderDetailClassInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 23, 44, 543, DateTimeKind.Local).AddTicks(1817));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
