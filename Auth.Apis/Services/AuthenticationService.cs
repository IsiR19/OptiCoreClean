using Auth.Core.Enums;
using Auth.Core.Exceptions;
using Auth.Core.Interfaces;
using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using Auth.DomainLogic.Interfaces;

namespace Auth.DomainLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Fields

        private readonly IAuthCacheService _authCacheService;
        private readonly IGoogleService _googleService;

        #endregion Private Fields

        #region Public Constructors

        public AuthenticationService(IGoogleService googleService, IAuthCacheService authCacheService)
        {
            _googleService = googleService;
            _authCacheService = authCacheService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<SessionResponse> CreateUserSessionAsync(LoginRequest loginRequest)
        {
            var validationResult = await _googleService.ValidateIdTokenAsync(loginRequest.GoogleIdToken);
            if (!validationResult.Validated)
            {
                throw AuthenticationException.Token(validationResult.Exception!.Message);
            }
            var userUID = validationResult.Data!.Subject;
            var sessionGuid = Guid.NewGuid().ToString();
            var expireAt = validationResult.Data?.ExpirationTimeSeconds ?? DateTimeOffset.Now.AddMinutes(5).ToUnixTimeSeconds();

            _authCacheService.SetSessionInformation(userUID, sessionGuid, expireAt, loginRequest.IpAddress);
            return new SessionResponse(sessionGuid, expireAt, userUID);
        }

        public void EndUserSession(SessionRequest sessionRequest)
        {
            _authCacheService.BlacklistSession(sessionRequest.SessionGuid);
        }

        public SessionResponse GetUserSession(SessionRequest sessionRequest)
        {
            var sessionInformation = _authCacheService.GetSessionInformation(sessionRequest.SessionGuid);
            if (sessionInformation == null)
            {
                throw AuthenticationException.NoSession();
            }
            if (sessionInformation.ExpireUTC < DateTime.UtcNow)
            {
                throw  AuthenticationException.Session("Expired or Blacklisted.");
            }
            if (sessionInformation.IpAddress != sessionRequest.IpAddress)
            {
                throw AuthenticationException.Session("IP Mismatch.");
            }
            return new SessionResponse(sessionInformation.SessionGuid, sessionInformation.Expiry, sessionInformation.UserUID);
        }

        #endregion Public Methods
    }
}