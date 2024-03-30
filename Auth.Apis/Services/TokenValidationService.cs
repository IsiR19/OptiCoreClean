using Auth.Core.Interfaces.Configuration;
using Auth.Core.Models.Configuration;
using Auth.DomainLogic.Interfaces;
using Auth.DomainLogic.Models;
using MsIdentityTokens = Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;

namespace Auth.DomainLogic.Services
{
    public class TokenValidationService : ITokenValidationService
    {
        #region Private Fields

        private readonly TokenValidationConfiguration _configuration;
        private readonly MsIdentityTokens.TokenValidationParameters _tokenValidationParameters;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly HttpClient _httpClient;
        private readonly MsIdentityTokens.SecurityKey[] _issuerSigningKeys;
        #endregion Private Fields

        #region Public Constructors

        public TokenValidationService(IAuthConfiguration authConfiguration)
        {
            _configuration = authConfiguration.OAuthConfiguration;
            _httpClient = new HttpClient();
            _issuerSigningKeys = RetrieveSigningKeys();
            _tokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration.Issuer,
                ValidateAudience = true,
                ValidAudience = _configuration.Audience,
                ValidateLifetime = true,
                IssuerSigningKeys = _issuerSigningKeys
            };
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<TokenValidationResult> ValidateTokenAsync(string token)
        {
            try
            {
                var internalValidationResult = await _jwtSecurityTokenHandler.ValidateTokenAsync(token, _tokenValidationParameters);
                if (internalValidationResult == null)
                {
                    return TokenValidationResult.Error("Internal validation result was null");
                }
                if (internalValidationResult.Exception != null)
                {
                    return TokenValidationResult.Error(internalValidationResult.Exception);
                }
                return TokenValidationResult.Success(internalValidationResult.SecurityToken);
            }
            catch (Exception e)
            {
                return TokenValidationResult.Error(e);
            }
        }

        #endregion Public Methods

        private MsIdentityTokens.SecurityKey[] RetrieveSigningKeys()
        {
            List<MsIdentityTokens.SecurityKey> result = new List<MsIdentityTokens.SecurityKey>();
            foreach (var jwkUri in _configuration.JwksUris)
            {
                try
                {
                    var httpResponse = _httpClient.GetAsync(jwkUri).GetAwaiter().GetResult();
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        continue;
                    }
                    var jwkResponse = httpResponse.Content.ReadFromJsonAsync<JwkResponse>().GetAwaiter().GetResult();
                    if (jwkResponse == null)
                    {
                        continue;
                    }
                    result.AddRange(jwkResponse.Keys.Select(key => (MsIdentityTokens.SecurityKey)key));
                }

                catch (Exception e)
                {
                    continue;
                }
            }
            return result.ToArray();
        }
    }
}