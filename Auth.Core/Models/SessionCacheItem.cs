using System.Text.Json.Serialization;

namespace Auth.Core.Models
{
    public class SessionCacheItem
    {
        #region Public Properties

        [JsonIgnore]
        public DateTime ExpireUTC => DateTimeOffset.FromUnixTimeSeconds(Expiry).UtcDateTime;

        public long Expiry { get; set; }

        public string IpAddress { get; init; }

        public string SessionGuid { get; init; }

        public string UserUID { get; init; }

        #endregion Public Properties

        #region Public Constructors

        public SessionCacheItem()
        { }

        public SessionCacheItem(string sessionGuid, string userUID, string ipAddress, long expiry)
        {
            SessionGuid = sessionGuid;
            UserUID = userUID;
            IpAddress = ipAddress;
            Expiry = expiry;
        }

        #endregion Public Constructors
    }
}