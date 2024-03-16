using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using Auth.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.DomainLogic.Interfaces;
using Auth.Core.Common.Interfaces;
using Auth.Core.Exceptions;

namespace Auth.DomainLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IGoogleService _googleService;
        private readonly ICacheProvider _cacheProvider;

        public AuthenticationService(IGoogleService googleService, ICacheProvider cacheProvider)
        {
            _googleService = googleService;
            _cacheProvider = cacheProvider;
        }

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
    }
}
