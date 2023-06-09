using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace Ordersystem.DataObjects
{
    [Table("TblProduct")]
    public class Product
    {
        [Key]
        [Column("Product_ID")]
        public int ProductID { get; set; }
        [Required]
        [Column("Product_Title")]
        public string Title { get; set; }
        [Required]
        [Column("Product_Description")]
        public string Description { get; set; }
        [Required]
        [Column("Product_Price")]
        public double Price { get; set; }
        [Required]
        [Column("Product_UnitInStock")]
        [DisplayName("Unit in stock")]
        public int UnitInStock { get; set; }

        [ValidateNever]
        [ForeignKey("Supplier")]
        public int? SupplierID { get; set; }
        public Supplier? Supplier { get; set; }

        [ValidateNever]
        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }

        [ValidateNever]
        [Column("Product_ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
