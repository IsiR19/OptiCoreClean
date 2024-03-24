using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static Auth.Core.Constants;

namespace Auth.DomainLogic.Models
{
    public class TokenValidationResult
    {
        #region Public Properties

        public string Audience => GetPayloadValue<string>(TokenClaims.Audience);
        public string Email => GetPayloadValue<string>(TokenClaims.Email);
        public bool EmailVerified => GetPayloadValue<bool>(TokenClaims.EmailVerified);
        public Exception? Exception { get; init; }
        public DateTime Expiration => Token?.ValidTo ?? DateTime.MinValue;
        public DateTime IssuedAt => Token?.ValidFrom ?? DateTime.MinValue;
        public string Issuer => GetPayloadValue<string>(TokenClaims.Issuer);
        public string Name => GetPayloadValue<string>(TokenClaims.Name);
        public string Subject => Token?.Subject ?? "";
        public JwtSecurityToken? Token { get; init; }
        public bool Validated => Token != null && Exception == null;

        #endregion Public Properties

        #region Public Methods

        public static TokenValidationResult Error(Exception exception) => new TokenValidationResult() { Exception = exception };

        public static TokenValidationResult Error(string message) => new TokenValidationResult() { Exception = new Exception(message) };

        public static TokenValidationResult Success(SecurityToken data) => new TokenValidationResult() { Token = (JwtSecurityToken)data };

        #endregion Public Methods

        #region Private Methods

        private TValue GetPayloadValue<TValue>(string claim)
        {
            if (Token == null)
            {
                return default;
            }
            return (TValue)Token.Payload[claim];
        }

        #endregion Private Methods
    }
}