using Auth.Core.Common.Models;
using Auth.Core.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DependencyInjection.Models
{
    public class DependencyInjectionConfigurationBuilder
    {
        #region Private Properties

        private bool _addEntitlements { get; set; }
        private CacheConfiguration? _cacheConfiguration { get; set; }
        private GoogleOAuthConfiguration? _googleOAuthConfiguration { get; set; } = null;

        #endregion Private Properties

        #region Public Methods

        public DependencyInjectionConfigurationBuilder AddEntitlements()
        {
            _addEntitlements = true;
            return this;
        }

        public DependencyInjectionConfiguration Build()
        {
            if (_googleOAuthConfiguration == null)
            {
                throw new InvalidOperationException($"{nameof(WithGoogleOAuthConfiguration)} must be called");
            }
            if (_cacheConfiguration == null)
            {
                _cacheConfiguration = CacheConfiguration.Default;
            }
            var authConfig = new AuthConfiguration(_cacheConfiguration, _googleOAuthConfiguration);
            return new DependencyInjectionConfiguration()
            {
                AddEntitlements = _addEntitlements,
                AuthConfiguration = authConfig
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
            WithGoogleOAuthConfiguration(authConfiguration.OAuthConfiguration);
            return this;
        }

        public DependencyInjectionConfigurationBuilder WithGoogleOAuthConfiguration(IConfiguration configuration, string sectionName)
        {
            var clientId = configuration.GetSection($"{sectionName}:ClientId").Value ?? "";
            var clientSecret = configuration.GetSection($"{sectionName}:ClientSecret").Value ?? "";
            var loginPath = configuration.GetSection($"{sectionName}:LoginPath").Value ?? "";
            return WithGoogleOAuthConfiguration(new GoogleOAuthConfiguration(clientId, clientSecret, loginPath));
        }

        public DependencyInjectionConfigurationBuilder WithGoogleOAuthConfiguration(GoogleOAuthConfiguration googleOAuthConfiguration)
        {
            if (string.IsNullOrWhiteSpace(googleOAuthConfiguration.ClientId))
            {
                throw new ArgumentNullException($"{nameof(GoogleOAuthConfiguration)}.{nameof(googleOAuthConfiguration.ClientId)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(googleOAuthConfiguration.ClientSecret))
            {
                throw new ArgumentNullException($"{nameof(GoogleOAuthConfiguration)}.{nameof(googleOAuthConfiguration.ClientSecret)} was not supplied");
            }
            if (string.IsNullOrWhiteSpace(googleOAuthConfiguration.LoginPath))
            {
                throw new ArgumentNullException($"{nameof(GoogleOAuthConfiguration)}.{nameof(googleOAuthConfiguration.LoginPath)} was not supplied");
            }
            _googleOAuthConfiguration = googleOAuthConfiguration;
            return this;
        }

        #endregion Public Methods
    }
}