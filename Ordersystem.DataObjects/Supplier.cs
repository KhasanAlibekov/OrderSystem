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
        [RegularExpression("^BE[0-9]{10}$", ErrorMessage = "VAT number must start with BE and have 10 digits.")]
        public string VATNumber { get; set; }

        [Required]
        [Column("Supplier_Name")]
        [DisplayName("Supplier Name")]
        public string? SupplierName { get; set; }

        [Column("Supplier_Address")]
        [DisplayName("Address")]
        [RegularExpression("^[0-9]+[a-zA-Z -]*$", ErrorMessage = "Please fill in house number and street name.")]
        public string? Address { get; set; }

        [Column("Supplier_City")]
        public string? City { get; set; }

        [Column("Supplier_PostalCode")]
        [DisplayName("Postal Code")]
        [RegularExpression("^[1-9][0-9]{3}$", ErrorMessage = "Postal code must not start with 0 and should have 4 digits.")]
        public string? PostalCode { get; set;}

        [Column("Supplier_Country")]
        public string? Country { get; set; }

        [Column("Supplier_PhoneNumber")]
        [DisplayName("Phone Number")]
        [RegularExpression("^0032[0-9]{9}$", ErrorMessage = "Phone number must start with 0032 and have 9 digits.")]
        public string? Phone { get; set; }

        [Column("Supplier_Email")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Invalid email address. (example@something.com")]
        public string? Email { get; set; }
    }
}
