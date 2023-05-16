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
        [Key]
        [Column("Id")]
        public int SupplierID { get; set; }
        [Required]
        public int VATNumber { get; set; }
        [Required]
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set;}
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
