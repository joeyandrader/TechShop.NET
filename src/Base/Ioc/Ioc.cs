using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Repository;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Repositorys;
using BackEndAPI.src.Services;

namespace BackEndAPI.src.Base.Ioc
{
    public class Ioc
    {
        public static void ConfigureDependencieInjector(IServiceCollection services)
        {
            //Repositorys
            services.AddScoped<IRepository<Usuario, int>, UsuarioRepository<Usuario, int>>();

            //Services
            services.AddScoped<IService<Usuario, int>, UsuarioService<Usuario, int>>();
        }
    }
}