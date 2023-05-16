using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    [Table("TblProduct")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int UnitInStock { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
