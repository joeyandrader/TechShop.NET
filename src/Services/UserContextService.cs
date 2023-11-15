using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.src.Base.Contracts.Service;

namespace BackEndAPI.src.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserContextData GetUserContextData()
        {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue("UserContextData", out var userContextData))
            {
                return userContextData as UserContextData;
            }
            return null;
        }
    }
}