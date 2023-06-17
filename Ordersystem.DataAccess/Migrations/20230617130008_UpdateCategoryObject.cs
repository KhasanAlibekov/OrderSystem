using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProduct_TblCategory_CategoryID",
                table: "TblProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProduct_TblSupplier_SupplierID",
                table: "TblProduct");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "TblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 15, 0, 8, 258, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.AddForeignKey(
                name: "FK_TblProduct_TblCategory_CategoryID",
                table: "TblProduct",
                column: "CategoryID",
                principalTable: "TblCategory",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProduct_TblSupplier_SupplierID",
                table: "TblProduct",
                column: "SupplierID",
                principalTable: "TblSupplier",
                principalColumn: "Supplier_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProduct_TblCategory_CategoryID",
                table: "TblProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProduct_TblSupplier_SupplierID",
                table: "TblProduct");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "TblProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TblProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8,
                column: "Message_Date",
                value: new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.AddForeignKey(
                name: "FK_TblProduct_TblCategory_CategoryID",
                table: "TblProduct",
                column: "CategoryID",
                principalTable: "TblCategory",
                principalColumn: "Category_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProduct_TblSupplier_SupplierID",
                table: "TblProduct",
                column: "SupplierID",
                principalTable: "TblSupplier",
                principalColumn: "Supplier_ID");
        }
    }
}
