using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string Name { get; set; }
        [PersonalData]
        public string? StreetAddress { get; set; }
        [PersonalData]
        public string? City { get; set; }
        [PersonalData]
        public string? PostalCode { get; set; }
    }
}
