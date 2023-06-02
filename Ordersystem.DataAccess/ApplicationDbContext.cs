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
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
