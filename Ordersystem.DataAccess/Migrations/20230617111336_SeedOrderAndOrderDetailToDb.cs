using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ordersystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderAndOrderDetailToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblOrder_AspNetUsers_ApplicationUserID",
                table: "TblOrder");

            migrationBuilder.DropIndex(
                name: "IX_TblOrder_ApplicationUserID",
                table: "TblOrder");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "TblOrder");

            migrationBuilder.DropColumn(
                name: "Order_ShippingDate",
                table: "TblOrder");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_TblOrderDetail_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "TblOrderDetail",
                        principalColumn: "OrderDetail_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 1,
                column: "Category_Name",
                value: "Watches");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 2,
                column: "Category_Name",
                value: "Perfumes");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 3,
                column: "Category_Name",
                value: "Eyewear");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 4,
                column: "Category_Name",
                value: "Headphones");

            migrationBuilder.InsertData(
                table: "TblCategory",
                columns: new[] { "Category_ID", "Category_Name" },
                values: new object[,]
                {
                    { 5, "Fitness Trackers" },
                    { 6, "Speakers" },
                    { 7, "Kitchen Tools" },
                    { 8, "Charging Accessories" }
                });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "Dear customers, we would like to inform you that there will be scheduled maintenance on our systems this weekend. During this time, you may experience temporary service interruptions. We apologize for any inconvenience caused and appreciate your understanding.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8055), "Important Update: Maintenance Schedule" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "We are excited to announce the release of a new feature that will enhance your experience on our platform. The feature allows you to customize your profile and personalize your settings. We hope you enjoy this new addition and look forward to your feedback.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8127), "Status Update: New Feature Release" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "Attention all users, we have recently detected suspicious activity on some user accounts. As a precautionary measure, we have reset passwords for those accounts and implemented additional security measures. Please ensure that your password is strong and unique. If you have any concerns, please contact our support team immediately.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8130), "Important Announcement: Security Alert" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "We are pleased to inform you that the service disruption we experienced earlier has been resolved. Our technical team has identified and resolved the issue, and all services are now operating normally. Thank you for your patience and understanding.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8134), "Status Update: Service Disruption Resolved" });

            migrationBuilder.InsertData(
                table: "TblMessage",
                columns: new[] { "Message_ID", "Message_Content", "Message_Date", "Message_Title", "Message_Type" },
                values: new object[,]
                {
                    { 5, "We are thrilled to announce the launch of our new product line. Join us on [Date] for an exclusive product launch event where you can be the first to experience our latest innovations. Don't miss this exciting opportunity to discover cutting-edge technology and explore new possibilities.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8138), "Important Announcement: Product Launch Event", 1 },
                    { 6, "We are currently undergoing a system upgrade to enhance performance and introduce new features. During this time, you may experience intermittent service disruptions. Rest assured, our team is working diligently to minimize any inconvenience. We appreciate your patience and understanding.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8142), "Status Update: System Upgrade", 0 },
                    { 7, "Mark your calendars for our highly anticipated annual sale event! Get ready for incredible discounts and exclusive offers on a wide range of products. This is your chance to save big and enjoy unbeatable deals. Don't miss out on this limited-time opportunity!", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8146), "Important Announcement: Annual Sale Event", 1 },
                    { 8, "We are excited to introduce a new customer support channel to better serve you. Our dedicated support team is now available via live chat on our website. Simply visit our support page and click on the chat icon to connect with a representative. We're here to assist you with any inquiries or concerns.", new DateTime(2023, 6, 17, 13, 13, 35, 785, DateTimeKind.Local).AddTicks(8150), "Status Update: New Customer Support Channel", 0 }
                });

            migrationBuilder.InsertData(
                table: "TblOrder",
                columns: new[] { "Order_Id", "Order_OrderCount", "Order_OrderDate", "OrderStatus", "PaymentStatus" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { 2, 5, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { 3, 8, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true },
                    { 4, 3, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { 5, 2, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false },
                    { 6, 7, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true },
                    { 7, 4, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false },
                    { 8, 6, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true }
                });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 1,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "Add a touch of sophistication to your style with this elegant wristwatch. Featuring a sleek design and precise timekeeping, it's a perfect accessory for both formal and casual occasions.", "Elegant Wristwatch" });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 2,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "Indulge your senses with this luxurious perfume. With its captivating fragrance and long-lasting scent, it's sure to leave a lasting impression. Perfect for special occasions or everyday wear.", "Luxurious Perfume" });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 3,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "Protect your eyes in style with these fashionable sunglasses. Designed with UV protection and a trendy frame, they not only shield your eyes from the sun but also elevate your fashion game.", "Stylish Sunglasses" });

            migrationBuilder.InsertData(
                table: "TblProduct",
                columns: new[] { "Product_ID", "CategoryID", "Product_Description", "Product_ImageUrl", "Product_Price", "SupplierID", "Product_Title", "Product_UnitInStock" },
                values: new object[] { 4, 2, "Immerse yourself in high-quality audio with these premium headphones. Perfect for music lovers and audiophiles, these headphones deliver exceptional sound clarity and comfort.", "", 149.99000000000001, 4, "Premium Headphones", 5 });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "123 Main Street", "New York", "United States", "abc@corporation.com", "555-1234", "10001", "ABC Corporation", 987654321 });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 3,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "456 Elm Avenue", "London", "United Kingdom", "info@xyzltd.com", "+44 20 1234 5678", "SW1A 1AA", "XYZ Ltd.", 654321987 });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 4,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "789 Oak Lane", "Sydney", "Australia", "sales@globale.com", "+61 2 9876 5432", "2000", "Global Enterprises", 246813579 });

            migrationBuilder.InsertData(
                table: "TblSupplier",
                columns: new[] { "Supplier_ID", "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[,]
                {
                    { 5, "10 Park Avenue", "Toronto", "Canada", "info@megasuppliers.com", "+1 416-123-4567", "M5B 1B1", "Mega Suppliers Inc.", 135792468 },
                    { 6, "Rue de la Liberté", "Paris", "France", "contact@eurotrade.com", "+33 1 2345 6789", "75001", "Euro Trade", 864209753 },
                    { 7, "123 Market Street", "Tokyo", "Japan", "sales@asiawholesale.com", "+81 3-1234-5678", "100-0005", "Asia Wholesale", 370592864 },
                    { 8, "Avenida del Sol", "São Paulo", "Brazil", "info@southamericasup", "+55 11 98765-4321", "01234-567", "SouthAmerica Suppliers", 958746213 }
                });

            migrationBuilder.InsertData(
                table: "TblOrderDetail",
                columns: new[] { "OrderDetail_Id", "OrderID", "ProductID", "OrderDetail_Quantity", "OrderDetail_UnitPrice" },
                values: new object[,]
                {
                    { 1, 2, 1, 18, 10.0 },
                    { 2, 2, 3, 12, 5.9900000000000002 },
                    { 3, 3, 2, 5, 100.98999999999999 },
                    { 4, 3, 4, 2, 149.99000000000001 }
                });

            migrationBuilder.InsertData(
                table: "TblProduct",
                columns: new[] { "Product_ID", "CategoryID", "Product_Description", "Product_ImageUrl", "Product_Price", "SupplierID", "Product_Title", "Product_UnitInStock" },
                values: new object[,]
                {
                    { 5, 2, "Track your fitness goals and monitor your health with this advanced smart fitness tracker. It features an intuitive touchscreen, heart rate monitoring, sleep tracking, and a variety of sports modes to help you stay active and motivated.", "", 79.989999999999995, 5, "Smart Fitness Tracker", 8 },
                    { 6, 3, "Take your music wherever you go with this portable Bluetooth speaker. With its compact design and powerful sound output, it's perfect for outdoor gatherings, parties, and trips. Enjoy wireless connectivity and long battery life.", "", 49.990000000000002, 6, "Portable Bluetooth Speaker", 15 },
                    { 7, 3, "Enhance your culinary skills with this high-quality professional chef's knife. The razor-sharp blade is crafted from premium stainless steel for precision cutting and durability. A must-have tool for every aspiring chef.", "", 89.989999999999995, 7, "Professional Chef's Knife", 3 },
                    { 8, 3, "Simplify your charging routine with this wireless charging pad. Compatible with a wide range of smartphones and devices, it provides fast and convenient charging without the hassle of cables. Just place your device on the pad and let it power up.", "", 29.989999999999998, 8, "Wireless Charging Pad", 12 }
                });

            migrationBuilder.InsertData(
                table: "TblOrderDetail",
                columns: new[] { "OrderDetail_Id", "OrderID", "ProductID", "OrderDetail_Quantity", "OrderDetail_UnitPrice" },
                values: new object[,]
                {
                    { 5, 4, 6, 8, 49.990000000000002 },
                    { 6, 4, 5, 3, 79.989999999999995 },
                    { 7, 5, 7, 1, 89.989999999999995 },
                    { 8, 5, 8, 4, 29.989999999999998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OrderDetailID",
                table: "ShoppingCarts",
                column: "OrderDetailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblOrderDetail",
                keyColumn: "OrderDetail_Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblOrder",
                keyColumn: "Order_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "TblOrder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Order_ShippingDate",
                table: "TblOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 1,
                column: "Category_Name",
                value: "Trucks");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 2,
                column: "Category_Name",
                value: "Phones");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 3,
                column: "Category_Name",
                value: "Sport");

            migrationBuilder.UpdateData(
                table: "TblCategory",
                keyColumn: "Category_ID",
                keyValue: 4,
                column: "Category_Name",
                value: "Broadcast");

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 1,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "Nothing will be done today", new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(1941), "okdokdoqsqs" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 2,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2009), "kfneofnoenfoeznfoeznfoezofezofezofez" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 3,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2011), "ezdjezfoejzofjezfjezofoeznfoezfoez" });

            migrationBuilder.UpdateData(
                table: "TblMessage",
                keyColumn: "Message_ID",
                keyValue: 4,
                columns: new[] { "Message_Content", "Message_Date", "Message_Title" },
                values: new object[] { "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", new DateTime(2023, 6, 16, 18, 31, 3, 299, DateTimeKind.Local).AddTicks(2013), "oqssjsqjdçazjdozdozod" });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 1,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "Somethings happen for a reason", "Something" });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 2,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "Nothing will be done today", "Nothing" });

            migrationBuilder.UpdateData(
                table: "TblProduct",
                keyColumn: "Product_ID",
                keyValue: 3,
                columns: new[] { "Product_Description", "Product_Title" },
                values: new object[] { "IDK is my motto", "IDK" });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "Je ne sais pas 4", "Lille", "France", "france@gmail.com", "989997478688699", "9807", "Unilever", 87966676 });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 3,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "Niet goed 7", "Nergens", "Zwitserland", "zweten@gmail.com", "79797987987987", "9807", "Ok", 765868797 });

            migrationBuilder.UpdateData(
                table: "TblSupplier",
                keyColumn: "Supplier_ID",
                keyValue: 4,
                columns: new[] { "Supplier_Address", "Supplier_City", "Supplier_Country", "Supplier_Email", "Supplier_PhoneNumber", "Supplier_PostalCode", "Supplier_Name", "Supplier_VATNumber" },
                values: new object[] { "Niet goed 4", "Praag", "Tsjechie", "czech@gmail.com", "878787", "98787", "Goedzo", 87666565 });

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
    }
}
