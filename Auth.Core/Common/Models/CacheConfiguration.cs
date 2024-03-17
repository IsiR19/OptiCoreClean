using Auth.Core.Common.Enums;

namespace Auth.Core.Common.Models
{
    public class CacheConfiguration
    {
        public virtual int LifetimeMins { get; set; }
        public virtual CacheProviders Provider { get; set; }

        public CacheConfiguration(int lifetimeMins, CacheProviders provider)
        {
            LifetimeMins = lifetimeMins;
            Provider = provider;
        }

        public static CacheConfiguration Default => new CacheConfiguration(15, CacheProviders.Memory);
    }
}
