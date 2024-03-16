using Auth.Core.Common.Interfaces;
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

        private readonly ICacheProvider _cacheProvider;
        private readonly IGoogleService _googleService;

        #endregion Private Fields

        #region Public Constructors

        public AuthenticationService(IGoogleService googleService, ICacheProvider cacheProvider)
        {
            _googleService = googleService;
            _cacheProvider = cacheProvider;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<LoginResponse> LoginWithGoogle(LoginRequest loginRequest)
        {
            var validationResult = await _googleService.ValidateIdTokenAsync(loginRequest.GoogleIdToken);
            if (!validationResult.Validated)
            {
                throw AuthenticationException.Token(validationResult.Exception!.Message);
            }
            var userUUID = validationResult.Data!.Subject;
            var sessionId = Guid.NewGuid().ToString();
            //  TODO: Get expiration
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}