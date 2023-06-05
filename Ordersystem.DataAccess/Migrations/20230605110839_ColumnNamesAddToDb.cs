using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNamesAddToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VATNumber",
                table: "TblSupplier",
                newName: "Supplier_VATNumber");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "TblSupplier",
                newName: "Supplier_Name");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "TblSupplier",
                newName: "Supplier_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "TblSupplier",
                newName: "Supplier_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TblSupplier",
                newName: "Supplier_Email");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "TblSupplier",
                newName: "Supplier_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "TblSupplier",
                newName: "Supplier_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "TblSupplier",
                newName: "Supplier_Address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblSupplier",
                newName: "Supplier_ID");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "TblCategory",
                newName: "Category_Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblCategory",
                newName: "Category_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Supplier_VATNumber",
                table: "TblSupplier",
                newName: "VATNumber");

            migrationBuilder.RenameColumn(
                name: "Supplier_PostalCode",
                table: "TblSupplier",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Supplier_PhoneNumber",
                table: "TblSupplier",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Supplier_Name",
                table: "TblSupplier",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Supplier_Email",
                table: "TblSupplier",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Supplier_Country",
                table: "TblSupplier",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Supplier_City",
                table: "TblSupplier",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Supplier_Address",
                table: "TblSupplier",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Supplier_ID",
                table: "TblSupplier",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Category_Name",
                table: "TblCategory",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Category_ID",
                table: "TblCategory",
                newName: "Id");
        }
    }
}
