﻿using Auth.Core.Enums;
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
        private readonly ITokenValidationService _tokenValidationService;

        #endregion Private Fields

        #region Public Constructors

        public AuthenticationService(ITokenValidationService tokenValidationService, IAuthCacheService authCacheService)
        {
            _tokenValidationService = tokenValidationService;
            _authCacheService = authCacheService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<SessionResponse> CreateOrRestoreUserSessionAsync(LoginRequest loginRequest)
        {
            var validationResult = await _tokenValidationService.ValidateTokenAsync(loginRequest.GoogleIdToken);
            if (!validationResult.Validated)
            {
                throw AuthenticationException.Token(validationResult.Exception!.Message);
            }
            string sessionGuid;
            var userUID = validationResult.Subject;
            if (!_authCacheService.CheckForUserSession(userUID, out sessionGuid))
            {
                sessionGuid = Guid.NewGuid().ToString();
            }
            var expireAt = validationResult.Expiration != DateTime.MinValue ? ((DateTimeOffset)validationResult.Expiration).ToUnixTimeSeconds() : DateTimeOffset.Now.AddMinutes(5).ToUnixTimeSeconds();

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
                throw AuthenticationException.Session("Expired or Blacklisted.");
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