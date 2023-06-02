using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ordersystem.DataObjects
{
    [Table("TblProduct")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public int ProductID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int UnitInStock { get; set; }

        [ForeignKey(nameof(Supplier))]
        [ValidateNever]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(Category))]
        [ValidateNever]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
