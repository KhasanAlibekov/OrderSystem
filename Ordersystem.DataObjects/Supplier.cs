using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordersystem.DataObjects
{
    [Table("TblSupplier")]
    public class Supplier
    {
        [Key]
        [Column("Supplier_ID")]
        public int SupplierID { get; set; }

        [Required]
        [Column("Supplier_VATNumber")]
        [DisplayName("VAT Number")]
        public string VATNumber { get; set; }

        [Required]
        [Column("Supplier_Name")]
        [DisplayName("Supplier Name")]
        public string? SupplierName { get; set; }

        [Column("Supplier_Address")]
        [DisplayName("Address")]
        public string? Address { get; set; }

        [Column("Supplier_City")]
        public string? City { get; set; }

        [Column("Supplier_PostalCode")]
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set;}

        [Column("Supplier_Country")]
        public string? Country { get; set; }

        [Column("Supplier_PhoneNumber")]
        [DisplayName("Phone Number")]
        public string? Phone { get; set; }

        [Column("Supplier_Email")]
        [DisplayName("E-mail")]
        public string? Email { get; set; }
    }
}
