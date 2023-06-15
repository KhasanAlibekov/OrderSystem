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
    [Table("TblOrder")]
    public class Order
    {
        [Key]
        [Column("Id")]
        public int OrderID { get; set; }
        [Range(1, 999, ErrorMessage = "Please enter a value between 1 and 999")]
        public int OrderCount { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Product_ID")]
        [ValidateNever]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("ApplicationUser_ID")]
        [ValidateNever]
        public int ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
