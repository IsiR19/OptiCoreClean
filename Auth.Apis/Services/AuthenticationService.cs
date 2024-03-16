using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using Auth.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<LoginResponse> LoginWithGoogle(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
