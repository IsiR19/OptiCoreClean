using Auth.Core.Interfaces;
using Auth.Core;
using Auth.Core.Interfaces.Models;
using Microsoft.AspNetCore.Http;

namespace Auth.DomainLogic.Services
{
    public class UserResolver : IUserResolver
    {
        #region Private Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private string? _sessionGuid = "";
        private IUser? _user;

        #endregion Private Fields

        #region Public Properties

        public string Email => _user?.Email ?? Constants.UserResolver.System;

        public string Name => _user?.Name ?? Constants.UserResolver.System;

        public string Session => _sessionGuid ?? Constants.UserResolver.System;

        public string UUID => _user?.UUID ?? Constants.UserResolver.System;

        #endregion Public Properties

        #region Public Constructors

        public UserResolver(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
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
            if (!_httpContextAccessor.HttpContext.Items.TryGetValue(Constants.HttpContextItems.userUID, out object? _userUid))
            {
                return;
            }
            try
            {
                _user = _userService.GetUserByUuidUIDAsync(_userUid.ToString()!).GetAwaiter().GetResult();
            }
            catch
            {
            }
        }

        #endregion Private Methods
    }
}