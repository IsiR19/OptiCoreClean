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
using Auth.Core.Services;

namespace Auth.Middleware.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        #region Private Fields

        private readonly IAuthorizationServerInteractor _authorizationServerInteractor;
        private readonly bool _isEntitlement;
        private readonly string _policyOrEntitlement;
        private readonly IEntitlementPolicyService _policyService;
        private readonly IUserResolver _userResolver;
        private string? _sessionGuid;

        #endregion Private Fields

        #region Private Properties

        private bool _noEntitlementsCheck
        {
            get
            {
                if (_policyService is DisabledPolicyService)
                {
                    return true;
                }
                return _policyOrEntitlement == Constants.Policies.None;
            }
        }

        #endregion Private Properties

        #region Public Constructors

        public AuthorizationFilter(IAuthorizationServerInteractor authorizationServerInteractor, IUserResolver userResolver, IEntitlementPolicyService policyService, string policyOrEntitlement, bool isEntitlement)
        {
            _authorizationServerInteractor = authorizationServerInteractor;
            _policyOrEntitlement = policyOrEntitlement;
            _isEntitlement = isEntitlement;
            _userResolver = userResolver;
            _policyService = policyService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }
            try
            {
                var session = await ValidateSessionAsync(context);
                if (session == null)
                {
                    throw AuthenticationException.Session("Invalid session");
                }
                await ValidateAccessAsync(session);
            }
            catch (AuthenticationException ae)
            {
                switch (ae.Cause)
                {
                    case Core.Enums.AuthenticationExceptionCause.Entitlements:
                        context.Result = new ForbidResult();
                        break;

                    default:
                        context.Result = new UnauthorizedObjectResult(ae.Message);
                        break;
                }
                return;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private async Task ValidateAccessAsync(SessionResponse session)
        {
            if (_noEntitlementsCheck)
            {
                return;
            }
            if (_isEntitlement)
            {
                ValidateEntitlements(session, _policyOrEntitlement, true);
                return;
            }
            await ValidatePolicyAsync(session);
        }

        private bool ValidateEntitlements(SessionResponse session, string entitlement, bool throwIfMissing)
        {
            if (session.Entitlements.Contains(Constants.Entitlements.SystemAdmin))
            {
                return true;
            }
            if (session.Entitlements.Contains(entitlement))
            {
                return true;
            }
            if (throwIfMissing)
            {
                throw AuthenticationException.Entitlements();
            }
            return false;
        }

        private async Task ValidatePolicyAsync(SessionResponse session)
        {
            var policy = await _policyService.GetPolicyByCodeAsync(_policyOrEntitlement);
            var entitlementPassCount = 0;
            if (policy == null)
            {
                return;
            }
            foreach (var entitlement in policy.Entitlements)
            {
                if (ValidateEntitlements(session, entitlement.Code, false))
                {
                    entitlementPassCount++;
                }
            }
            if (entitlementPassCount == 0)
            {
                throw AuthenticationException.Entitlements();
            }
        }

        private async Task<SessionResponse> ValidateSessionAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue(Constants.Cookies.Session, out _sessionGuid))
            {
                context.HttpContext.Items.TryAdd(Constants.HttpContextItems.SessionGuid, _sessionGuid);
            }
            var sessionInfo = await _authorizationServerInteractor.GetUserSessionAsync();
            return sessionInfo;
        }

        #endregion Private Methods
    }
}