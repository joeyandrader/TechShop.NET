using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;

namespace BackEndAPI.src.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthResponse> Auth(AuthRequest auth)
        {
            Usuario user = await _repository.Auth(auth);
            if (user == null)
                throw new Exception("Dados Invalido!");
            var validaPassword = user.ValidaSenha(auth.Password);
            if (!validaPassword)
                throw new Exception("Dados invalido");
            return TokenService.GenerateToken(user);
        }
    }
}