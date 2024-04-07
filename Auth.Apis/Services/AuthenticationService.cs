using Auth.Core;
using Auth.Core.Exceptions;
using Auth.Core.Interfaces;
using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using Auth.DomainLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Auth.DomainLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Fields

        private readonly IAuthCacheService _authCacheService;
        private readonly ITokenValidationService _tokenValidationService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Private Fields

        #region Public Constructors

        public AuthenticationService(IHttpContextAccessor httpContextAccessor, ITokenValidationService tokenValidationService, IAuthCacheService authCacheService, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenValidationService = tokenValidationService;
            _authCacheService = authCacheService;
            _userService = userService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<SessionResponse> CreateOrRestoreUserSessionAsync(LoginRequest loginRequest)
        {
            var validationResult = await ValidateTokenAsync(loginRequest.AccessToken);
            string sessionGuid;
            var userUID = validationResult.Subject;
            var hasExistingSession = GetOrCreateSessionGuid(userUID, out sessionGuid);

            if (!hasExistingSession)
            {
                await ValidateUserIsRegisteredAsync(userUID, validationResult.Email);
            }
            var expireAt = validationResult.Expiration != DateTime.MinValue ? ((DateTimeOffset)validationResult.Expiration).ToUnixTimeSeconds()
                : DateTimeOffset.Now.AddMinutes(5).ToUnixTimeSeconds();

            SetHttpContextItems(sessionGuid, userUID);
            var entitlementDetails = await _userService.GetUserEntitlementsAsync(userUID);
            var entitlements = entitlementDetails.Select(entitlement => entitlement.Code);
            CacheSessionInformation(userUID, sessionGuid, expireAt, loginRequest.IpAddress, entitlements);
            return new SessionResponse(sessionGuid, expireAt, userUID, entitlements);
        }

        public void EndUserSession(SessionRequest sessionRequest)
        {
            _authCacheService.BlacklistSession(sessionRequest.SessionGuid);
        }

        public async Task<SessionResponse> GetUserSessionAsync(SessionRequest sessionRequest)
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
            var entitlements = _authCacheService.GetEntitlements(sessionInformation.UserUID);
            SetHttpContextItems(sessionInformation.SessionGuid, sessionInformation.UserUID);
            return new SessionResponse(sessionInformation.SessionGuid, sessionInformation.Expiry, sessionInformation.UserUID, entitlements);
        }

        #endregion Public Methods

        #region Private Methods

        private bool GetOrCreateSessionGuid(string userUID, out string sessionGuid)
        {
            if (!_authCacheService.CheckForUserSession(userUID, out sessionGuid))
            {
                sessionGuid = Guid.NewGuid().ToString();
                return false;
            }
            return true;
        }

        private async Task<Models.TokenValidationResult> ValidateTokenAsync(string accessToken)
        {
            var validationResult = await _tokenValidationService.ValidateTokenAsync(accessToken);
            if (!validationResult.Validated)
            {
                throw AuthenticationException.Token(validationResult.Exception!.Message);
            }
            return validationResult;
        }

        private async Task ValidateUserIsRegisteredAsync(string userUID, string email)
        {
            var user = await _userService.GetUserByUuidAsync(userUID);
            if (user == null)
            {
                throw AuthenticationException.NotRegistered(email);
            }
            if (user.Email.ToLower() != email.ToLower())
            {
                throw AuthenticationException.Discrepancy(nameof(user.Email));
            }
        }

        private void SetHttpContextItems(string sessionGuid, string userUid)
        {
            _httpContextAccessor.HttpContext.Items.TryAdd(Constants.HttpContextItems.SessionGuid, sessionGuid);
            _httpContextAccessor.HttpContext.Items.TryAdd(Constants.HttpContextItems.UserUID, userUid);
        }

        private void CacheSessionInformation(string userUID, string sessionGuid, long expireAtSeconds, string ipAddress, IEnumerable<string> entitlements)
        {
            _authCacheService.SetSessionInformation(userUID, sessionGuid, expireAtSeconds, ipAddress);
            _authCacheService.SetEntitlements(userUID, entitlements);
        }

        #endregion Private Methods
    }
}