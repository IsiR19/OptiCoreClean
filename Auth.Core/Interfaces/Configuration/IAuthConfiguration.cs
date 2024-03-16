using Auth.Core.Common.Models;
using Auth.Core.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Configuration
{
    public interface IAuthConfiguration
    {
        public CacheConfiguration Cache { get; set; }
        public GoogleOAuthConfiguration OAuthConfiguration { get; set; }
    }
}
