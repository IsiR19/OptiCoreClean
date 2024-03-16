using Microsoft.Extensions.Options;
using OptiCore.Application.Abstractions.Contracts.Email;
using OptiCore.Application.Models.Email;
using System.Net;
using System.Net.Mail;

namespace Opticore.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        private readonly SmtpClient _smtpClient;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
            _smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort);
            _smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
            _smtpClient.EnableSsl = _emailSettings.EnableSs1;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(email.From);
                    mailMessage.To.Add(email.To);
                    mailMessage.Subject = email.Subject;
                    mailMessage.Body = email.Body;

                    await _smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Add logging
                return false;
            }
        }
    }
}