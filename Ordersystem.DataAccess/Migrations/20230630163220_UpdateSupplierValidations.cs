using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 32, 20, 45, DateTimeKind.Local).AddTicks(6368));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 30, 18, 26, 37, 750, DateTimeKind.Local).AddTicks(5912));
        }
    }
}
