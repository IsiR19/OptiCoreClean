using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opticore.Infrastructure.EmailService;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Application.Models.Email;

namespace Opticore.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings").Value);
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
