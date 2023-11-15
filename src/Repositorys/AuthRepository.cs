using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.DB;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.src.Repositorys
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Usuario> Auth(AuthRequest auth)
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.Where(x => x.Email == auth.Email);
            if (query == null)
                throw new Exception("Dados invalidos, ou usuario não existe");
            return await query.FirstOrDefaultAsync();
        }
    }
}