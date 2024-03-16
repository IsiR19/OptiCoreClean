namespace Auth.Core.Common.Models
{
    public class SessionCacheItem
    {
        public string SessionId { get; set; }
        public string UserUID { get; set; }
        public DateTime Expirey { get; set; }
    }
}
