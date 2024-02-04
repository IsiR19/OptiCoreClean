using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opticore.Persistence.DatabaseContext;

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
            return services;
        }
    }
}
