
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Auth.DomainLogic.Models
{
    public class TokenValidationResult
    {
        #region Public Properties

        public JwtSecurityToken? Token { get; init; }
        public Exception? Exception { get; init; }
        public bool Validated => Token != null && Exception == null;

        public string Subject => Token?.Subject ?? "";
        public DateTime Expiration => Token?.ValidTo ?? DateTime.MinValue;

        #endregion Public Properties

        #region Public Methods

        public static TokenValidationResult Error(Exception exception) => new TokenValidationResult() { Exception = exception };
        public static TokenValidationResult Error(string message) => new TokenValidationResult() { Exception = new Exception(message) };

        public static TokenValidationResult Success(SecurityToken data) => new TokenValidationResult() { Token = (JwtSecurityToken)data };

        #endregion Public Methods
    }
}