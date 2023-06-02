using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSuppierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "TblProduct",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TblSupplier",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "Phone", "PostalCode", "SupplierName", "VATNumber" },
                values: new object[] { 1, "Pluim 4", "Zwevegem", "Belgium", "notyours@gmail.com", "0478688699", "9807", "Syntra", 123456789 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblProduct");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblProduct");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TblProduct",
                newName: "ProductName");
        }
    }
}
