using Auth.DomainLogic.Interfaces;
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
        public Task<GoogleJsonWebSignature.Payload> ValidateIdTokenAsync(string idToken)
        {
            throw new NotImplementedException();
        }
    }
}
