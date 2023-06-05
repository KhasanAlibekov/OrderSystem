using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    [Table("TblSupplier")]
    public class Supplier
    {
        [Key] // data annotation
        [Column("Supplier_ID")]
        public int SupplierID { get; set; }
        [Required]
        [Column("Supplier_VATNumber")]
        public int VATNumber { get; set; }
        [Required]
        [Column("Supplier_Name")]
        public string? SupplierName { get; set; }
        [Column("Supplier_Address")]
        public string? Address { get; set; }
        [Column("Supplier_City")]
        public string? City { get; set; }
        [Column("Supplier_PostalCode")]
        public string? PostalCode { get; set;}
        [Column("Supplier_Country")]
        public string? Country { get; set; }
        [Column("Supplier_PhoneNumber")]
        public string? Phone { get; set; }
        [Column("Supplier_Email")]
        public string? Email { get; set; }
    }
}
