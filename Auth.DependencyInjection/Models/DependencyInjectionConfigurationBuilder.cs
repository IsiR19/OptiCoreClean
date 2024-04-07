using Auth.Core.Common.Models;
using Auth.Core.Interfaces;
using Auth.Core.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Auth.Core.Constants;

namespace Auth.DependencyInjection.Models
{
    public class DependencyInjectionConfigurationBuilder
    {
        #region Private Properties

        private bool _addEntitlements { get; set; }
        private CacheConfiguration? _cacheConfiguration { get; set; }
        private Type? _entitlementPolicyServiceType { get; set; }
        private TokenValidationConfiguration? _tokenValidationConfiguration { get; set; } = null;
        private Func<IServiceProvider, object>? _userServiceImplementationFactory { get; set; }
        private Type? _userServiceType { get; set; }

        #endregion Private Properties

        #region Public Methods

        public DependencyInjectionConfiguration Build()
        {
            if (_tokenValidationConfiguration == null)
            {
                throw new InvalidOperationException($"{nameof(WithTokenValidation)} must be called");
            }
            if (_cacheConfiguration == null)
            {
                _cacheConfiguration = CacheConfiguration.Default;
            }
            if (_userServiceType == null)
            {
                throw new InvalidOperationException($"{nameof(WithUserService)} must be called");
            }
            var authConfig = new AuthConfiguration(_cacheConfiguration, _tokenValidationConfiguration);
            return new DependencyInjectionConfiguration()
            {
                AddEntitlements = _addEntitlements,
                AuthConfiguration = authConfig,
                UserServiceConfiguration = new UserServiceDependencyInjectionConfiguration { ImplementationType = _userServiceType, ImplementationFactory = _userServiceImplementationFactory },
                EntitlementPolicyServiceType = _entitlementPolicyServiceType
            };
        }

        public DependencyInjectionConfigurationBuilder WithCache(CacheConfiguration cacheConfiguration)
        {
            _cacheConfiguration = cacheConfiguration;
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithConfiguration(AuthConfiguration authConfiguration)
        {
            if (authConfiguration.Cache == null)
            {
                authConfiguration.Cache = CacheConfiguration.Default;
            }
            WithCache(authConfiguration.Cache);
            if (authConfiguration.OAuthConfiguration == null)
            {
                throw new ArgumentNullException($"{nameof(AuthConfiguration)}.{nameof(authConfiguration.OAuthConfiguration)} was not supplied");
            }
            WithTokenValidation(authConfiguration.OAuthConfiguration);
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithEntitlements()
        {
            _addEntitlements = true;
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithEntitlements<TPolicyService>() where TPolicyService : IEntitlementPolicyService
        {
            _addEntitlements = true;
            _entitlementPolicyServiceType = typeof(TPolicyService);
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithTokenValidation(IConfiguration configuration)
        {
            var clientId = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.ClientId) ?? configuration[ConfigurationKeys.AppSettings.Firebase.ClientId] ?? "";
            var clientSecret = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.ClientSecret) ?? configuration[ConfigurationKeys.AppSettings.Firebase.ClientSecret] ?? "";
            var tokenUri = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.TokenUri) ?? configuration[ConfigurationKeys.AppSettings.Firebase.TokenUri] ?? "";
            var audience = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.ProjectId) ?? configuration[ConfigurationKeys.AppSettings.Firebase.ProjectId] ?? "";
            var issuer = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.Issuer) ?? configuration[ConfigurationKeys.AppSettings.Firebase.Issuer] ?? "";
            var jwkUris = Environment.GetEnvironmentVariable(ConfigurationKeys.Environment.Firebase.JwksUris) ?? configuration[ConfigurationKeys.AppSettings.Firebase.JwksUris] ?? "";
            return WithTokenValidation(new TokenValidationConfiguration(clientId, clientSecret, tokenUri, audience, issuer, jwkUris.Split(',')));
        }

        public DependencyInjectionConfigurationBuilder WithTokenValidation(TokenValidationConfiguration tokenConfiguration)
        {
            if (string.IsNullOrWhiteSpace(tokenConfiguration.ClientId))
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.ClientId)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(tokenConfiguration.ClientSecret))
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.ClientSecret)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(tokenConfiguration.TokenUri))
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.TokenUri)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(tokenConfiguration.Audience))
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.Audience)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(tokenConfiguration.Issuer))
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.Issuer)} was not supplied");
            }
            if (tokenConfiguration.JwksUris == null)
            {
                throw new ArgumentNullException($"{nameof(TokenValidationConfiguration)}.{nameof(tokenConfiguration.JwksUris)} was not supplied");
            }
            _tokenValidationConfiguration = tokenConfiguration;
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithUserService<TUserService>() where TUserService : IUserService
        {
            _userServiceType = typeof(TUserService);
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithUserService<TUserService>(Func<IServiceProvider, object> implementationFactory) where TUserService : IUserService
        {
            _userServiceType = typeof(TUserService);
            var factoryReturnType = implementationFactory.GetMethodInfo().ReturnType;
            if (!_userServiceType.IsAssignableFrom(factoryReturnType))
            {
                throw new ArgumentException($"{nameof(implementationFactory)} does not return a type that inherits from {_userServiceType.FullName}");
            }
            _userServiceImplementationFactory = implementationFactory;
            return this;
        }

        #endregion Public Methods
    }
}