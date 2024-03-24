using Auth.Core;
using Auth.Core.Exceptions;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Models.Requests;
using Auth.Core.Models.Responses;
using Auth.DomainLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Services
{
    /// <summary>
    /// This only exists until the Auth project becomes its own service
    /// </summary>
    public class InternalAuthorizationServerInteractor : IAuthorizationServerInteractor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;
        private readonly string _requestIpAddress;
        private string? _sessionGuid;

        public InternalAuthorizationServerInteractor(IHttpContextAccessor httpContextAccessor, IAuthenticationService authenticationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationService = authenticationService;

            _requestIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (_httpContextAccessor.HttpContext.Items.TryGetValue(Constants.HttpContextItems.SessionGuid, out var _sessionGuidObj))
            {
                _sessionGuid = _sessionGuidObj.ToString();
            }
            else
            {
                _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(Constants.Cookies.Session, out _sessionGuid);
            }
        }

        public async Task<SessionResponse> CreateUserSessionAsync(string accessToken)
        {
            return await _authenticationService.CreateOrRestoreUserSessionAsync(new LoginRequest(accessToken, _requestIpAddress));
        }

        public async Task EndUserSessionAsync()
        {
            if (string.IsNullOrEmpty(_sessionGuid))
            {
                return;
            }
            _authenticationService.EndUserSession(GenerateSessionRequest());
            await Task.CompletedTask;
        }

        public async Task<SessionResponse> GetUserSessionAsync()
        {
            var result = _authenticationService.GetUserSession(GenerateSessionRequest());
            return await Task.FromResult(result);
        }

        private SessionRequest GenerateSessionRequest()
        {
            if(!TryGetSessionGuid(out _sessionGuid))
            {
                throw AuthenticationException.NoSession();
            }
            return new SessionRequest()
            {
                IpAddress = _requestIpAddress,
                SessionGuid = _sessionGuid!
            };
        }

        private bool TryGetSessionGuid(out string sessionGuid)
        {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue(Constants.HttpContextItems.SessionGuid, out var _sessionGuidObj))
            {
                sessionGuid = _sessionGuidObj!.ToString()!;
                return true;
            }
            return _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(Constants.Cookies.Session, out sessionGuid);

        }
    }
}
