using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opticore.Persistance.DatabaseContext;

namespace Opticore.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
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
