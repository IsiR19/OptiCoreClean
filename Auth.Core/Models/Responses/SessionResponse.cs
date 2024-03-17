using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Responses
{
    public class SessionResponse
    {
        #region Public Properties

        /// <summary>
        /// The <seealso cref="DateTime"/> of the session Id's expiration
        /// </summary>
        public DateTime Expiry { get; init; }

        /// <summary>
        /// The session GUID for the currently logged in user
        /// </summary>
        public string SessionGuid { get; init; }

        /// <summary>
        /// The user's UUID
        /// </summary>
        public string UserUID { get; init; }

        #endregion Public Properties

        #region Public Constructors

        public SessionResponse()
        { }

        public SessionResponse(string sessionGuid, DateTime expiry, string userUID)
        {
            SessionGuid = sessionGuid;
            Expiry = expiry;
            UserUID = userUID;
        }

        public SessionResponse(string sessionGuid, long expirationTimeSeconds, string userUID)
        {
            SessionGuid = sessionGuid;
            Expiry = DateTimeOffset.FromUnixTimeSeconds(expirationTimeSeconds).UtcDateTime;
            UserUID = userUID;
        }

        #endregion Public Constructors
    }
}