namespace Auth.Core.Models.Configuration
{
    public class TokenValidationConfiguration
    {
        #region Public Properties

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenUri { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string[] JwksUris { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public TokenValidationConfiguration()
        { }

        public TokenValidationConfiguration(string clientId, string clientSecret, string tokenUri, string audience, string issuer, string[] jwksUris)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            TokenUri = tokenUri;
            Audience = audience;
            Issuer = issuer;
            JwksUris = jwksUris;
        }


        #endregion Public Constructors
    }
}