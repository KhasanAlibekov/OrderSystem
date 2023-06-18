using Microsoft.AspNetCore.Identity.UI.Services;

namespace Ordersystem.DataObjects
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Logic for sending mail 
            return Task.CompletedTask;
        }
    }
}
