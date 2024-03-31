using Auth.Core.Interfaces;
using Auth.Core;
using Auth.Core.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using Auth.DomainLogic.Interfaces;

namespace Auth.DomainLogic.Services
{
    public class UserResolver : IUserResolver
    {
        #region Private Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IAuthCacheService _authCacheService;
        private string? _sessionGuid = "";
        private IUser? _user;
        private IEnumerable<string>? _entitlements;

        #endregion Private Fields

        #region Public Properties

        public string Email
        {
            get
            {
                TrySetContext();
                return _user?.Email ?? Constants.UserResolver.System;
            }
        }

        public string Name
        {
            get
            {
                TrySetContext();
                return _user?.Name ?? Constants.UserResolver.System;
            }
        }

        public string Session
        {
            get
            {
                TrySetContext();
                return _sessionGuid ?? string.Empty;
            }
        }

        public string UUID
        {
            get
            {
                TrySetContext();
                return _user?.UUID ?? Constants.UserResolver.System;
            }
        }

        public IEnumerable<string> Entitlements
        {
            get
            {
                TrySetContext();
                return _entitlements ?? Enumerable.Empty<string>();
            }
        }

        #endregion Public Properties

        #region Public Constructors

        public UserResolver(IHttpContextAccessor httpContextAccessor, IUserService userService, IAuthCacheService authCacheService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _authCacheService = authCacheService;
            TrySetContext();
        }

        #endregion Public Constructors

        #region Private Methods

        private void TrySetContext()
        {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue(Constants.HttpContextItems.SessionGuid, out object? _sessionGuidObj))
            {
                _sessionGuid = _sessionGuidObj?.ToString();
            }
            TrySetUserContext();
        }

        private void TrySetUserContext()
        {
            if (_user != null)
            {
                return;
            }
            if (!_httpContextAccessor.HttpContext.Items.TryGetValue(Constants.HttpContextItems.UserUID, out object? _userUid))
            {
                return;
            }
            try
            {
                _user = _userService.GetUserByUuidUIDAsync(_userUid.ToString()!).GetAwaiter().GetResult();
                if (_user == null)
                {
                    return;
                }
                _entitlements = _authCacheService.GetEntitlements(UUID);
            }
            catch
            {
            }
        }

        #endregion Private Methods
    }
}