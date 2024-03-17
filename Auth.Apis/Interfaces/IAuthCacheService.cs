using Auth.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Interfaces
{
    public interface IAuthCacheService
    {
        public void SetSessionInformation(string userUID, string sessionGuid, long expireAtSeconds, string ipAddress);
        public SessionCacheItem? GetSessionInformation(string sessionGuid);
        public void BlacklistSession(string sessionGuid);
    }
}
