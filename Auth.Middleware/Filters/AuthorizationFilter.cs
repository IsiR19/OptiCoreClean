using Auth.Core;
using Auth.Core.Exceptions;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Models.Responses;
using Auth.Middleware.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Middleware.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationServerInteractor _authorizationServerInteractor;
        private readonly string _policy;
        private string? _sessionGuid;
        private bool _noPolicy => _policy == Constants.Policies.None;

        public AuthorizationFilter(IHttpContextAccessor httpContextAccessor, IAuthorizationServerInteractor authorizationServerInteractor, string policy)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorizationServerInteractor = authorizationServerInteractor;
            _policy = policy;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }
            try
            {
                await ValidateSessionAsync(context);
            }
            catch (AuthenticationException ae)
            {
                context.Result = new UnauthorizedObjectResult(ae.Message);
                return;
            }
            if (_noPolicy)
            {
                return;
            }
            // TODO: Add in entitlements
        }

        private async Task ValidateSessionAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue(Constants.Cookies.Session, out _sessionGuid))
            {
                context.HttpContext.Items.Add(Constants.HttpContextItems.SessionGuid, _sessionGuid);
            }
            var sessionInfo = await _authorizationServerInteractor.GetUserSessionAsync();
            context.HttpContext.Items.Add(Constants.HttpContextItems.userUID, sessionInfo.UserUID);
        }

    }
}
