using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public  Task<LoginResponse> LoginWithGoogle(LoginRequest loginRequest);
    }
}
