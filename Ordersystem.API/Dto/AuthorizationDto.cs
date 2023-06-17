namespace Ordersystem.API.Dto
{
    public class AuthorizationDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
