using Auth.DomainLogic.Models;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Interfaces
{
    public interface ITokenValidationService
    {
        Task<TokenValidationResult> ValidateTokenAsync(string token);
    }
}
