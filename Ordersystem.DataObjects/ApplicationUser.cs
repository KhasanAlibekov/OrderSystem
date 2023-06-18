using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ordersystem.DataObjects
{
    // Adds extra information to the IdentityUser
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }            // The name of the user
        public string? StreetAddress { get; set; }  // The street address of the user (optional)
        public string? City { get; set; }           // The city of the user (optional)
        public string? PostalCode { get; set; }     // The postal code of the user (optional)
    }
}
