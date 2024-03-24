using Auth.Core.Interfaces;
using Auth.Core.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DomainLogic.Services
{
    public class UserResolver : IUserResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private IUser _user;

        public UserResolver(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            // make "ensure user" method
        }

        public string Name => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public string UUID => throw new NotImplementedException();

        public string Session => throw new NotImplementedException();
    }
}
