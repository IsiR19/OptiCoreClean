using Auth.Core.Common.Models;
using Auth.Core.Interfaces.Configuration;

namespace Auth.Core.Models.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        public CacheConfiguration Cache { get; set; }
        public TokenValidationConfiguration OAuthConfiguration { get; set; }
        public AuthConfiguration(CacheConfiguration cacheConfiguration, TokenValidationConfiguration oauthConfiguration)
        {
            Cache = cacheConfiguration;
            OAuthConfiguration = oauthConfiguration;
        }
    }
}
