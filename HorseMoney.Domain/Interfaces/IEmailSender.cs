namespace HorseMoney.Domain.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}