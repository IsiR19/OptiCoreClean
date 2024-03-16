using Auth.Core.Interfaces.Configuration;
using Auth.Core.Models.Configuration;
using Auth.DomainLogic.Interfaces;
using Auth.DomainLogic.Models;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Services
{
    public class GoogleService : IGoogleService
    {
        #region Private Fields

        private readonly GoogleOAuthConfiguration _configuration;
        private readonly GoogleJsonWebSignature.ValidationSettings _googleSigninSettings;

        #endregion Private Fields

        #region Public Constructors

        public GoogleService(IAuthConfiguration authConfiguration)
        {
            _configuration = authConfiguration.OAuthConfiguration;
            _googleSigninSettings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { _configuration.ClientId }
            };
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<GoogleValidationResult> ValidateIdTokenAsync(string idToken)
        {
            try
            {
                var validatedData = await GoogleJsonWebSignature.ValidateAsync(idToken, _googleSigninSettings);
                return GoogleValidationResult.Success(validatedData);
            }
            catch (InvalidJwtException e)
            {
                return GoogleValidationResult.Error(e);
            }
        }

        #endregion Public Methods
    }
}