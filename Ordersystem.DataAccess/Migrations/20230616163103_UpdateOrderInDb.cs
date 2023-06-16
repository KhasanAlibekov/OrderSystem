using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "TblOrder");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "TblOrder",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2013));

            migrationBuilder.CreateIndex(
                name: "IX_TblOrder_ApplicationUserID",
                table: "TblOrder",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrder_AspNetUsers_ApplicationUserID",
                table: "TblOrder",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrder_AspNetUsers_ApplicationUserID",
                table: "TblOrder");

            migrationBuilder.DropIndex(
                name: "IX_TblOrder_ApplicationUserID",
                table: "TblOrder");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "TblOrder",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationID",
                table: "TblOrder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 16, 6, 732, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 16, 6, 732, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 16, 6, 732, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                column: "Message_Date",
                value: new DateTime(2023, 6, 16, 18, 16, 6, 732, DateTimeKind.Local).AddTicks(4117));
        }
    }
}
