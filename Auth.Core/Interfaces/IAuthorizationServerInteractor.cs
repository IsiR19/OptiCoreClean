using Auth.Core.Models;
using Auth.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    /// <summary>
    /// This interface will act as comms layer between the API and the Auth server
    /// </summary>
    public interface IAuthorizationServerInteractor
    {
        Task<SessionResponse> CreateUserSessionAsync(string accessToken);
        Task<SessionResponse> GetUserSessionAsync();
        Task EndUserSessionAsync();
    }
}
