using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 16, 33, 48, 244, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 6,
                column: "Product_Title",
                value: "Bluetooth Speaker");

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 7,
                column: "Product_Title",
                value: "Chef's Knife");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 3, 47, 125, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 6,
                column: "Product_Title",
                value: "Portable Bluetooth Speaker");

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 7,
                column: "Product_Title",
                value: "Professional Chef's Knife");
        }
    }
}
