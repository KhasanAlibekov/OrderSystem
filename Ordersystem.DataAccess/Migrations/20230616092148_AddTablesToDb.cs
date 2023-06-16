using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "TblMessage",
                columns: table => new
                {
                    Message_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Message_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMessage", x => x.Message_ID);
                });

            migrationBuilder.CreateTable(
                name: "TblOrder",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_OrderCount = table.Column<int>(type: "int", nullable: false),
                    Order_OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrder", x => x.Order_Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "TblOrderDetail",
                columns: table => new
                {
                    OrderDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetail_UnitPrice = table.Column<double>(type: "float", nullable: false),
                    OrderDetail_Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrderDetail", x => x.OrderDetail_Id);
                    table.ForeignKey(
                        name: "FK_TblOrderDetail_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblOrderDetail_TblOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "TblOrder",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblOrderDetail_TblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "TblProduct",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
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
                table: "TblMessage",
                columns: new[] { "Message_ID", "Message_Content", "Message_Date", "Message_Title", "Type" },
                values: new object[,]
                {
                    { 1, "Nothing will be done today", new DateTime(2023, 6, 16, 11, 21, 48, 569, DateTimeKind.Local).AddTicks(2810), "okdokdoqsqs", 1 },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2023, 6, 16, 11, 21, 48, 569, DateTimeKind.Local).AddTicks(2888), "kfneofnoenfoeznfoeznfoezofezofezofez", 0 },
                    { 3, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTime(2023, 6, 16, 11, 21, 48, 569, DateTimeKind.Local).AddTicks(2891), "ezdjezfoejzofjezfjezofoeznfoezfoez", 1 },
                    { 4, "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTime(2023, 6, 16, 11, 21, 48, 569, DateTimeKind.Local).AddTicks(2893), "oqssjsqjdçazjdozdozod", 0 }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrderDetail_ApplicationUserID",
                table: "TblOrderDetail",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrderDetail_OrderID",
                table: "TblOrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrderDetail_ProductID",
                table: "TblOrderDetail",
                column: "ProductID");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TblMessage");

            migrationBuilder.DropTable(
                name: "TblOrderDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
