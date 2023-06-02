using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class SupplierDto
    {
        [Required(ErrorMessage = "Please provide a category name")]
        public int VATNumber { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
