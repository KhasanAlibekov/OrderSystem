using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Supplier_VATNumber",
                table: "TblSupplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 48, 10, 502, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 1,
                column: "Supplier_VATNumber",
                value: "123456789");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                column: "Supplier_VATNumber",
                value: "987654321");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 3,
                column: "Supplier_VATNumber",
                value: "654321987");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 4,
                column: "Supplier_VATNumber",
                value: "246813579");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 5,
                column: "Supplier_VATNumber",
                value: "135792468");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 6,
                column: "Supplier_VATNumber",
                value: "864209753");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 7,
                column: "Supplier_VATNumber",
                value: "370592864");

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 8,
                column: "Supplier_VATNumber",
                value: "958746213");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Supplier_VATNumber",
                table: "TblSupplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 19, 1, 45, 36, 326, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 1,
                column: "Supplier_VATNumber",
                value: 123456789);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                column: "Supplier_VATNumber",
                value: 987654321);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 3,
                column: "Supplier_VATNumber",
                value: 654321987);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 4,
                column: "Supplier_VATNumber",
                value: 246813579);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 5,
                column: "Supplier_VATNumber",
                value: 135792468);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 6,
                column: "Supplier_VATNumber",
                value: 864209753);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 7,
                column: "Supplier_VATNumber",
                value: 370592864);

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 8,
                column: "Supplier_VATNumber",
                value: 958746213);
        }
    }
}
