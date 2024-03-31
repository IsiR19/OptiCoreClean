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
        /// <summary>
        /// Will set session information for the specified user
        /// </summary>
        /// <param name="userUID"></param>
        /// <param name="sessionGuid"></param>
        /// <param name="expireAtSeconds"></param>
        /// <param name="ipAddress"></param>
        public void SetSessionInformation(string userUID, string sessionGuid, long expireAtSeconds, string ipAddress);
        /// <summary>
        /// Will try get existing session information 
        /// </summary>
        /// <param name="sessionGuid"></param>
        /// <returns>null if no session exists</returns>
        public SessionCacheItem? GetSessionInformation(string sessionGuid);
        /// <summary>
        /// Checks if the user already has a session linked to them
        /// </summary>
        /// <param name="userUID"></param>
        /// <param name="existingSessionGuid"></param>
        /// <returns></returns>
        public bool CheckForUserSession(string userUID, out string existingSessionGuid);
        /// <summary>
        /// Blacklists the specified session
        /// </summary>
        /// <param name="sessionGuid"></param>
        public void BlacklistSession(string sessionGuid);

        public void SetEntitlements(string userUID, IEnumerable<string> entitlements);
        public IEnumerable<string> GetEntitlements(string userUID);
    }
}
