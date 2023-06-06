using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategory",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategory", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "TblOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAmount = table.Column<double>(type: "float", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shipped = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReceived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSupplier",
                columns: table => new
                {
                    Supplier_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_VATNumber = table.Column<int>(type: "int", nullable: false),
                    Supplier_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supplier_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSupplier", x => x.Supplier_ID);
                });

            migrationBuilder.CreateTable(
                name: "TblProduct",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<double>(type: "float", nullable: false),
                    Product_UnitInStock = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    Product_ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProduct", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_TblProduct_TblCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "TblCategory",
                        principalColumn: "Category_ID");
                    table.ForeignKey(
                        name: "FK_TblProduct_TblSupplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "TblSupplier",
                        principalColumn: "Supplier_ID");
                });

            migrationBuilder.InsertData(
                table: "TblCategory",
                columns: new[] { "Category_ID", "Category_Name" },
                values: new object[,]
                {
                    { 1, "Trucks" },
                    { 2, "Phones" },
                    { 3, "Sport" },
                    { 4, "Broadcast" }
                });

            migrationBuilder.InsertData(
                table: "TblSupplier",
                columns: new[] { "Supplier_ID", "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[,]
                {
                    { 1, "Pluim 4", "Zwevegem", "Belgium", "notyours@gmail.com", "0478688699", "9807", "Syntra", 123456789 },
                    { 2, "Je ne sais pas 4", "Lille", "France", "france@gmail.com", "989997478688699", "9807", "Unilever", 87966676 },
                    { 3, "Niet goed 7", "Nergens", "Zwitserland", "zweten@gmail.com", "79797987987987", "9807", "Ok", 765868797 },
                    { 4, "Niet goed 4", "Praag", "Tsjechie", "czech@gmail.com", "878787", "98787", "Goedzo", 87666565 }
                });

            migrationBuilder.InsertData(
                table: "TblProduct",
                columns: new[] { "Product_ID", "CategoryID", "Product_Description", "Product_ImageUrl", "Product_Price", "SupplierID", "Product_Title", "Product_UnitInStock" },
                values: new object[,]
                {
                    { 1, 1, "Somethings happen for a reason", "", 9.9900000000000002, 1, "Something", 10 },
                    { 2, 1, "Nothing will be done today", "", 100.98999999999999, 2, "Nothing", 666 },
                    { 3, 1, "IDK is my motto", "", 0.98999999999999999, 3, "IDK", 879 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProduct_CategoryID",
                table: "TblProduct",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TblProduct_SupplierID",
                table: "TblProduct",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOrder");

            migrationBuilder.DropTable(
                name: "TblProduct");

            migrationBuilder.DropTable(
                name: "TblCategory");

            migrationBuilder.DropTable(
                name: "TblSupplier");
        }
    }
}
