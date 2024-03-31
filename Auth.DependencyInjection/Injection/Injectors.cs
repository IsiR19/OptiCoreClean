using Auth.Core.Common.Enums;
using Auth.Core.Common.Interfaces;
using Auth.Core.Common.Services.Providers;
using Auth.Core.Interfaces;
using Auth.Core.Interfaces.Configuration;
using Auth.Core.Services;
using Auth.DependencyInjection.Models;
using Auth.DomainLogic.Interfaces;
using Auth.DomainLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.DependencyInjection.Injection
{
    public static class Injectors
    {
        #region Public Methods

        public static IServiceCollection AddAuthServices(this IServiceCollection services, Action<DependencyInjectionConfigurationBuilder> builder)
        {
            var config = BuildConfiguration(builder);
            services.AddSingleton<IAuthConfiguration>(config.AuthConfiguration);
            services.AddUserServices(config.UserServiceConfiguration);
            services.AddCaching(config);
            services.AddAuthServices(config);
            services.AddEntitlementService(config);
            return services;
        }

        public static IServiceCollection AddInternalAuthServer(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationServerInteractor, InternalAuthorizationServerInteractor>();
            return services;
        }
        #endregion Public Methods

        #region Private Methods

        private static IServiceCollection AddAuthServices(this IServiceCollection services, DependencyInjectionConfiguration config)
        {
            services.AddSingleton<ITokenValidationService, TokenValidationService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }

        private static IServiceCollection AddCaching(this IServiceCollection services, DependencyInjectionConfiguration config)
        {
            services.AddSingleton(config.AuthConfiguration.Cache);
            services.AddSingleton<IAuthCacheService, AuthCacheService>();
            switch (config.AuthConfiguration.Cache.Provider)
            {
                case CacheProviders.Memory:
                    services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
                    break;

                case CacheProviders.None:
                    services.AddSingleton<ICacheProvider, NoCacheProvider>();
                    break;

                case CacheProviders.File:
                    services.AddSingleton<ICacheProvider, FileCacheProvider>();
                    break;
            }
            return services;
        }

        private static IServiceCollection AddEntitlementService(this IServiceCollection services, DependencyInjectionConfiguration config)
        {
            if(config.PolicyServiceType == null)
            {
                services.AddTransient<IPolicyService, DisabledPolicyService>();
                return services;
            }
            services.AddTransient(typeof(IPolicyService), config.PolicyServiceType);
            return services;
        }

        private static IServiceCollection AddUserServices(this IServiceCollection services, UserServiceDependencyInjectionConfiguration config)
        {
            if (config.ImplementationFactory != null)
            {
                services.AddTransient(typeof(IUserService), config.ImplementationFactory);
            }
            else
            {
                services.AddTransient(typeof(IUserService), config.ImplementationType);
            }
            services.AddScoped<IUserResolver, UserResolver>();
            return services;
        }

        private static DependencyInjectionConfiguration BuildConfiguration(Action<DependencyInjectionConfigurationBuilder> builder)
        {
            var dependencyInjectionConfigurationBuilder = new DependencyInjectionConfigurationBuilder();
            builder.Invoke(dependencyInjectionConfigurationBuilder);
            return dependencyInjectionConfigurationBuilder.Build();
        }

        #endregion Private Methods
    }
}