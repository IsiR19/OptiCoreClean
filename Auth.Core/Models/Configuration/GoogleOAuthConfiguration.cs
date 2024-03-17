namespace Auth.Core.Models.Configuration
{
    public class GoogleOAuthConfiguration
    {
        #region Public Properties

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string LoginPath { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public GoogleOAuthConfiguration()
        { }

        public GoogleOAuthConfiguration(string clientId, string clientSecret, string loginPath)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            LoginPath = loginPath;
        }

        #endregion Public Constructors
    }
}