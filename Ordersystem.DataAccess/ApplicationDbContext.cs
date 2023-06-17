using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ordersystem.DataObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8FFVHLE;Database=Ordersytem.DB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        // Seed Category, Product, Message and Supplier tables to the Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category data
            modelBuilder.Entity<Category>().HasData(
                   new Category { CategoryID = 1, CategoryName = "Watches" },
                   new Category { CategoryID = 2, CategoryName = "Perfumes" },
                   new Category { CategoryID = 3, CategoryName = "Eyewear" },
                   new Category { CategoryID = 4, CategoryName = "Headphones" },
                   new Category { CategoryID = 5, CategoryName = "Fitness Trackers" },
                   new Category { CategoryID = 6, CategoryName = "Speakers" },
                   new Category { CategoryID = 7, CategoryName = "Kitchen Tools" },
                   new Category { CategoryID = 8, CategoryName = "Charging Accessories" }
                   );
            #endregion

            #region Supplier data
            modelBuilder.Entity<Supplier>().HasData(
                    new Supplier
                    {
                        SupplierID = 1,
                        VATNumber = 123456789,
                        SupplierName = "Syntra",
                        Address = "Pluim 4",
                        City = "Zwevegem",
                        PostalCode = "9807",
                        Country = "Belgium",
                        Phone = "0478688699",
                        Email = "notyours@gmail.com",
                    },
                    new Supplier
                    {
                        SupplierID = 2,
                        VATNumber = 987654321,
                        SupplierName = "ABC Corporation",
                        Address = "123 Main Street",
                        City = "New York",
                        PostalCode = "10001",
                        Country = "United States",
                        Phone = "555-1234",
                        Email = "abc@corporation.com",
                    },
                    new Supplier
                    {
                        SupplierID = 3,
                        VATNumber = 654321987,
                        SupplierName = "XYZ Ltd.",
                        Address = "456 Elm Avenue",
                        City = "London",
                        PostalCode = "SW1A 1AA",
                        Country = "United Kingdom",
                        Phone = "+44 20 1234 5678",
                        Email = "info@xyzltd.com",
                    },
                    new Supplier
                    {
                        SupplierID = 4,
                        VATNumber = 246813579,
                        SupplierName = "Global Enterprises",
                        Address = "789 Oak Lane",
                        City = "Sydney",
                        PostalCode = "2000",
                        Country = "Australia",
                        Phone = "+61 2 9876 5432",
                        Email = "sales@globale.com",
                    },
                     new Supplier
                     {
                         SupplierID = 5,
                         VATNumber = 135792468,
                         SupplierName = "Mega Suppliers Inc.",
                         Address = "10 Park Avenue",
                         City = "Toronto",
                         PostalCode = "M5B 1B1",
                         Country = "Canada",
                         Phone = "+1 416-123-4567",
                         Email = "info@megasuppliers.com",
                     },
                     new Supplier
                     {
                         SupplierID = 6,
                         VATNumber = 864209753,
                         SupplierName = "Euro Trade",
                         Address = "Rue de la Liberté",
                         City = "Paris",
                         PostalCode = "75001",
                         Country = "France",
                         Phone = "+33 1 2345 6789",
                         Email = "contact@eurotrade.com",
                     },
                     new Supplier
                     {
                         SupplierID = 7,
                         VATNumber = 370592864,
                         SupplierName = "Asia Wholesale",
                         Address = "123 Market Street",
                         City = "Tokyo",
                         PostalCode = "100-0005",
                         Country = "Japan",
                         Phone = "+81 3-1234-5678",
                         Email = "sales@asiawholesale.com",
                     },
                     new Supplier
                     {
                         SupplierID = 8,
                         VATNumber = 958746213,
                         SupplierName = "SouthAmerica Suppliers",
                         Address = "Avenida del Sol",
                         City = "São Paulo",
                         PostalCode = "01234-567",
                         Country = "Brazil",
                         Phone = "+55 11 98765-4321",
                         Email = "info@southamericasup",
                     }
                    );
            #endregion

            #region Product data
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        SupplierID = 1,
                        CategoryID = 1,
                        ProductID = 1,
                        Title = "Elegant Wristwatch",
                        Description = "Add a touch of sophistication to your style with this elegant wristwatch. Featuring a sleek design and precise timekeeping, it's a perfect accessory for both formal and casual occasions.",
                        Price = 9.99D,
                        UnitInStock = 10,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 2,
                        CategoryID = 1,
                        ProductID = 2,
                        Title = "Luxurious Perfume",
                        Description = "Indulge your senses with this luxurious perfume. With its captivating fragrance and long-lasting scent, it's sure to leave a lasting impression. Perfect for special occasions or everyday wear.",
                        Price = 100.99D,
                        UnitInStock = 666,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 3,
                        CategoryID = 1,
                        ProductID = 3,
                        Title = "Stylish Sunglasses",
                        Description = "Protect your eyes in style with these fashionable sunglasses. Designed with UV protection and a trendy frame, they not only shield your eyes from the sun but also elevate your fashion game.",
                        Price = 0.99D,
                        UnitInStock = 879,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 4,
                        CategoryID = 2,
                        ProductID = 4,
                        Title = "Premium Headphones",
                        Description = "Immerse yourself in high-quality audio with these premium headphones. Perfect for music lovers and audiophiles, these headphones deliver exceptional sound clarity and comfort.",
                        Price = 149.99D,
                        UnitInStock = 5,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 5,
                        CategoryID = 2,
                        ProductID = 5,
                        Title = "Smart Fitness Tracker",
                        Description = "Track your fitness goals and monitor your health with this advanced smart fitness tracker. It features an intuitive touchscreen, heart rate monitoring, sleep tracking, and a variety of sports modes to help you stay active and motivated.",
                        Price = 79.99D,
                        UnitInStock = 8,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 6,
                        CategoryID = 3,
                        ProductID = 6,
                        Title = "Portable Bluetooth Speaker",
                        Description = "Take your music wherever you go with this portable Bluetooth speaker. With its compact design and powerful sound output, it's perfect for outdoor gatherings, parties, and trips. Enjoy wireless connectivity and long battery life.",
                        Price = 49.99D,
                        UnitInStock = 15,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 7,
                        CategoryID = 3,
                        ProductID = 7,
                        Title = "Professional Chef's Knife",
                        Description = "Enhance your culinary skills with this high-quality professional chef's knife. The razor-sharp blade is crafted from premium stainless steel for precision cutting and durability. A must-have tool for every aspiring chef.",
                        Price = 89.99D,
                        UnitInStock = 3,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 8,
                        CategoryID = 3,
                        ProductID = 8,
                        Title = "Wireless Charging Pad",
                        Description = "Simplify your charging routine with this wireless charging pad. Compatible with a wide range of smartphones and devices, it provides fast and convenient charging without the hassle of cables. Just place your device on the pad and let it power up.",
                        Price = 29.99D,
                        UnitInStock = 12,
                        ImageUrl = ""
                    }
                    );
                    #endregion

            #region Message data
         modelBuilder.Entity<Message>().HasData(
                    new Message
                    {
                        MessageID = 1,
                        Title = "Important Update: Maintenance Schedule",
                        Content = "Dear customers, we would like to inform you that there will be scheduled maintenance on our systems this weekend. During this time, you may experience temporary service interruptions. We apologize for any inconvenience caused and appreciate your understanding.",
                        Type = MessageType.ImportantAnnouncement,
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 2,
                        Title = "Status Update: New Feature Release",
                        Type = MessageType.StatusMessage,
                        Content = "We are excited to announce the release of a new feature that will enhance your experience on our platform. The feature allows you to customize your profile and personalize your settings. We hope you enjoy this new addition and look forward to your feedback.",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 3,
                        Title = "Important Announcement: Security Alert",
                        Type = MessageType.ImportantAnnouncement,
                        Content = "Attention all users, we have recently detected suspicious activity on some user accounts. As a precautionary measure, we have reset passwords for those accounts and implemented additional security measures. Please ensure that your password is strong and unique. If you have any concerns, please contact our support team immediately.",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 4,
                        Title = "Status Update: Service Disruption Resolved",
                        Type = MessageType.StatusMessage,
                        Content = "We are pleased to inform you that the service disruption we experienced earlier has been resolved. Our technical team has identified and resolved the issue, and all services are now operating normally. Thank you for your patience and understanding.",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 5,
                        Title = "Important Announcement: Product Launch Event",
                        Content = "We are thrilled to announce the launch of our new product line. Join us on [Date] for an exclusive product launch event where you can be the first to experience our latest innovations. Don't miss this exciting opportunity to discover cutting-edge technology and explore new possibilities.",
                        Type = MessageType.ImportantAnnouncement,
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 6,
                        Title = "Status Update: System Upgrade",
                        Type = MessageType.StatusMessage,
                        Content = "We are currently undergoing a system upgrade to enhance performance and introduce new features. During this time, you may experience intermittent service disruptions. Rest assured, our team is working diligently to minimize any inconvenience. We appreciate your patience and understanding.",
                        Date = DateTime.Now,
                    },
                     new Message
                     {
                         MessageID = 7,
                         Title = "Important Announcement: Annual Sale Event",
                         Content = "Mark your calendars for our highly anticipated annual sale event! Get ready for incredible discounts and exclusive offers on a wide range of products. This is your chance to save big and enjoy unbeatable deals. Don't miss out on this limited-time opportunity!",
                         Type = MessageType.ImportantAnnouncement,
                         Date = DateTime.Now,
                     },
                     new Message
                     {
                         MessageID = 8,
                         Title = "Status Update: New Customer Support Channel",
                         Type = MessageType.StatusMessage,
                         Content = "We are excited to introduce a new customer support channel to better serve you. Our dedicated support team is now available via live chat on our website. Simply visit our support page and click on the chat icon to connect with a representative. We're here to assist you with any inquiries or concerns.",
                         Date = DateTime.Now,
                     }
                    );
            #endregion

            #region OrderDetail data
            modelBuilder.Entity<OrderDetail>().HasData(
                    new OrderDetail
                    {
                        OrderDetailID = 1,
                        ProductID = 1,
                        OrderID = 2,
                        UnitPrice = 10,
                        Quantity = 18,
                    },
                    new OrderDetail
                    {
                        OrderDetailID = 2,
                        ProductID = 3,
                        OrderID = 2,
                        UnitPrice = 5.99,
                        Quantity = 12,
                    },
                    new OrderDetail
                    {
                        OrderDetailID = 3,
                        ProductID = 2,
                        OrderID = 3,
                        UnitPrice = 100.99,
                        Quantity = 5,
                    },
                    new OrderDetail
                    {
                        OrderDetailID = 4,
                        ProductID = 4,
                        OrderID = 3,
                        UnitPrice = 149.99,
                        Quantity = 2,
                    },
                    new OrderDetail
                    {
                        OrderDetailID = 5,
                        ProductID = 6,
                        OrderID = 4,
                        UnitPrice = 49.99,
                        Quantity = 8,
                    },
                    new OrderDetail
                    {
                        OrderDetailID = 6,
                        ProductID = 5,
                        OrderID = 4,
                        UnitPrice = 79.99,
                        Quantity = 3,
                    },
                     new OrderDetail
                     {
                         OrderDetailID = 7,
                         ProductID = 7,
                         OrderID = 5,
                         UnitPrice = 89.99,
                         Quantity = 1,
                     },
                     new OrderDetail
                     {
                         OrderDetailID = 8,
                         ProductID = 8,
                         OrderID = 5,
                         UnitPrice = 29.99,
                         Quantity = 4,
                     }
                    );
            #endregion

            #region Order data
            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                        OrderID = 1,
                        OrderCount = 10,
                        OrderDate = new DateTime(2023, 6, 1),
                        OrderStatus = true,
                        PaymentStatus = true
                    },
                    new Order
                    {
                        OrderID = 2,
                        OrderCount = 5,
                        OrderDate = new DateTime(2023, 6, 2),
                        OrderStatus = true,
                        PaymentStatus = false
                    },
                    new Order
                    {
                        OrderID = 3,
                        OrderCount = 8,
                        OrderDate = new DateTime(2023, 6, 3),
                        OrderStatus = false,
                        PaymentStatus = true
                    },
                    new Order
                    {
                        OrderID = 4,
                        OrderCount = 3,
                        OrderDate = new DateTime(2023, 6, 4),
                        OrderStatus = true,
                        PaymentStatus = true
                    },
                    new Order
                    {
                        OrderID = 5,
                        OrderCount = 2,
                        OrderDate = new DateTime(2023, 6, 5),
                        OrderStatus = false,
                        PaymentStatus = false
                    },
                    new Order
                    {
                        OrderID = 6,
                        OrderCount = 7,
                        OrderDate = new DateTime(2023, 6, 6),
                        OrderStatus = true,
                        PaymentStatus = true
                    },
                    new Order
                    {
                        OrderID = 7,
                        OrderCount = 4,
                        OrderDate = new DateTime(2023, 6, 7),
                        OrderStatus = true,
                        PaymentStatus = false
                    },
                    new Order
                    {
                        OrderID = 8,
                        OrderCount = 6,
                        OrderDate = new DateTime(2023, 6, 8),
                        OrderStatus = false,
                        PaymentStatus = true
                    }
                    );
            #endregion
        }
    }
}