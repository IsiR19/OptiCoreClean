using Auth.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
