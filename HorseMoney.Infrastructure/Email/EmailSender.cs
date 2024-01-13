using System.Net.Mail;
using System.Threading.Tasks;
using HorseMoney.Domain.Interfaces;


namespace Microsoft.Extensions.DependencyInjection.Email;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using (var client = new SmtpClient("smtp.example.com"))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("username", "password");
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@example.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
    }
}