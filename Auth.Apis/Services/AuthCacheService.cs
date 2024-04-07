using Auth.Core.Common.Interfaces;
using Auth.Core.Models;
using Auth.DomainLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Services
{
    public class AuthCacheService : IAuthCacheService
    {

        private readonly ICacheProvider _cacheProvider;

        public AuthCacheService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public void BlacklistSession(string sessionGuid)
        {
            var existingSession = GetSessionInformation(sessionGuid);
            if (existingSession == null)
            {
                return;
            }
            existingSession.Expiry = 0;
            _cacheProvider.Set(sessionGuid, existingSession, 60);
        }

        public bool CheckForUserSession(string userUID, out string existingSessionGuid)
        {
            return _cacheProvider.TryGet(userUID, out existingSessionGuid);
        }

        public IEnumerable<string> GetEntitlements(string userUID)
        {
            string key = $"{userUID}-entitlements";
            if(!_cacheProvider.TryGet(key, out string entitlementString))
            {
                return Enumerable.Empty<string>();
            }
            return entitlementString.Split(',');
        }

        public SessionCacheItem? GetSessionInformation(string sessionGuid)
        {
            if (_cacheProvider.TryGet(sessionGuid, out SessionCacheItem sessionCacheItem))
            {
                return sessionCacheItem;
            }
            return null;
        }

        public void SetEntitlements(string userUID, IEnumerable<string> entitlements)
        {
            string key = $"{userUID}-entitlements";
            _cacheProvider.Set(key, string.Join(",", entitlements));
        }

        public void SetSessionInformation(string userUID, string sessionGuid, long expireAtSeconds, string ipAddress)
        {
            var sessionCacheItem = new SessionCacheItem(sessionGuid, userUID, ipAddress, expireAtSeconds);
            var sessionExpireMinutes = (sessionCacheItem.ExpireUTC - DateTime.UtcNow).Minutes + 1;
            _cacheProvider.Set(sessionGuid, sessionCacheItem, sessionExpireMinutes);
            SetUserCheck(userUID, sessionGuid, sessionExpireMinutes);
        }

        private void SetUserCheck(string userUID, string sessionGuid, int sessionExpireMinutes)
        {
            _cacheProvider.Set(userUID, sessionGuid, sessionExpireMinutes);
        }

    }
}