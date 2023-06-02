using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplierTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblSupplier",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "Phone", "PostalCode", "SupplierName", "VATNumber" },
                values: new object[,]
                {
                    { 2, "Je ne sais pas 4", "Lille", "France", "france@gmail.com", "989997478688699", "9807", "Unilever", 87966676 },
                    { 3, "Niet goed 7", "Nergens", "Zwitserland", "zweten@gmail.com", "79797987987987", "9807", "Ok", 765868797 },
                    { 4, "Niet goed 4", "Praag", "Tsjechie", "czech@gmail.com", "878787", "98787", "Goedzo", 87666565 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
