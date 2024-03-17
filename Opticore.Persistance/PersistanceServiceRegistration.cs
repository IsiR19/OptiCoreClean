using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opticore.Persistance.Repositories;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace Opticore.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OptiCoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OptiCoreDatabaseConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IHeadOfficeRepository, HeadOfficeRepository>();
            services.AddScoped<ICpRepository, CpRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            return services;
        }
    }
}