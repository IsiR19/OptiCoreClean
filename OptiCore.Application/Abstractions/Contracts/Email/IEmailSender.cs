using OptiCore.Application.Models.Email;

namespace OptiCore.Application.Abstractions.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}