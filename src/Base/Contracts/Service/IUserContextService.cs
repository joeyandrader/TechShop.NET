using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;

namespace BackEndAPI.src.Base.Contracts.Service
{
    public interface IUserContextService
    {
        UserContextData GetUserContextData();
    }
}