using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.Models.Data;

namespace BackEndAPI.src.Base.Contracts.Repository
{
    public interface IAuthRepository
    {
        Task<Usuario> Auth(AuthRequest auth);
    }
}