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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }

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

        // Seed Category and Supplier tables to the Db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category data
            modelBuilder.Entity<Category>().HasData(
                   new Category { CategoryID = 1, CategoryName = "Trucks" },
                   new Category { CategoryID = 2, CategoryName = "Phones" },
                   new Category { CategoryID = 3, CategoryName = "Sport" },
                   new Category { CategoryID = 4, CategoryName = "Broadcast" }
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
                        VATNumber = 87966676,
                        SupplierName = "Unilever",
                        Address = "Je ne sais pas 4",
                        City = "Lille",
                        PostalCode = "9807",
                        Country = "France",
                        Phone = "989997478688699",
                        Email = "france@gmail.com",
                    },
                    new Supplier
                    {
                        SupplierID = 3,
                        VATNumber = 765868797,
                        SupplierName = "Ok",
                        Address = "Niet goed 7",
                        City = "Nergens",
                        PostalCode = "9807",
                        Country = "Zwitserland",
                        Phone = "79797987987987",
                        Email = "zweten@gmail.com",
                    },
                    new Supplier
                    {
                        SupplierID = 4,
                        VATNumber = 87666565,
                        SupplierName = "Goedzo",
                        Address = "Niet goed 4",
                        City = "Praag",
                        PostalCode = "98787",
                        Country = "Tsjechie",
                        Phone = "878787",
                        Email = "czech@gmail.com",
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
                        Title = "Something",
                        Description = "Somethings happen for a reason",
                        Price = 9.99D,
                        UnitInStock = 10,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 2,
                        CategoryID = 1,
                        ProductID = 2,
                        Title = "Nothing",
                        Description = "Nothing will be done today",
                        Price = 100.99D,
                        UnitInStock = 666,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        SupplierID = 3,
                        CategoryID = 1,
                        ProductID = 3,
                        Title = "IDK",
                        Description = "IDK is my motto",
                        Price = 0.99D,
                        UnitInStock = 879,
                        ImageUrl = ""
                    }
                    #endregion

                    //        #region Order data

                    //modelBuilder.Entity<Order>().HasData(
                    //        new Order
                    //        {
                    //            OrderID = 1,
                    //            OrderAmount = 1.99,
                    //            OrderDate = new DateTime(2020, 12, 2),
                    //            Shipped = true,
                    //            PaymentReceived = true,
                    //        },
                    //        new Order
                    //        {
                    //            OrderID = 2,
                    //            OrderAmount = 19.99,
                    //            OrderDate = new DateTime(2021, 1, 3),
                    //            Shipped = true,
                    //            PaymentReceived = true,
                    //        },
                    //        new Order
                    //        {
                    //            OrderID = 3,
                    //            OrderAmount = 1.99,
                    //            OrderDate = new DateTime(2020, 12, 2),
                    //            Shipped = true,
                    //            PaymentReceived = true,
                    //        }
                    //        #endregion
                    );
            modelBuilder.Entity<Message>().HasData(
                    new Message
                    {
                        MessageID = 1,
                        Title = "okdokdoqsqs",
                        Content = "Nothing will be done today",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 2,
                        Title = "kfneofnoenfoeznfoeznfoezofezofezofez",
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 3,
                        Title = "ezdjezfoejzofjezfjezofoeznfoezfoez",
                        Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                        Date = DateTime.Now,
                    },
                    new Message
                    {
                        MessageID = 4,
                        Title = "oqssjsqjdçazjdozdozod",
                        Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                        Date = DateTime.Now,
                    }
                    );
        }
    }
}