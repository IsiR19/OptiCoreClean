using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opticore.Infrastructure.EmailService;
using Opticore.Infrastructure.Logging;
using OptiCore.Application.Abstractions.Contracts.Email;
using OptiCore.Application.Models.Email;

namespace Opticore.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IApplicationLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
