using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class AuthenticationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
