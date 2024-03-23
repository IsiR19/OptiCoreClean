using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<SessionResponse> CreateOrRestoreUserSessionAsync(LoginRequest loginRequest);
        public SessionResponse GetUserSession(SessionRequest sessionRequest);
        public void EndUserSession(SessionRequest sessionRequest);
    }
}
