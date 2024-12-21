using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Vuespa.Api.Config;
using Vuespa.Data.Entities;

namespace Vuespa.Api.Services;

public class EmailSender(
    IOptions<EmailConfig> emailConfig,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
{
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        SendEmail(email, "Confirm your email", confirmationLink);
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        SendEmail(email, "Reset your password", string.Format(emailConfig.Value.ResetLink, resetCode));
        return Task.CompletedTask;
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        SendEmail(email, "Reset your password", resetLink.Replace(":5173", ":4242"));
        return Task.CompletedTask;
    }

    private void SendEmail(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(emailConfig.Value.From),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        var smtpClient = new SmtpClient(emailConfig.Value.Smtp.Host, emailConfig.Value.Smtp.Port)
        {
            Credentials = new NetworkCredential(emailConfig.Value.Smtp.Username, emailConfig.Value.Smtp.Password),
            EnableSsl =  emailConfig.Value.Smtp.UseSSL
        };

        try
        {
            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error sending email");
            throw;
        }
    }
}