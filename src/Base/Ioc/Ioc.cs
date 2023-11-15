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
            services.AddScoped<IRepository<Product, int>, ProductRepository<Product, int>>();
            services.AddScoped<IRepository<Category, int>, CategoryRepository<Category, int>>();
            services.AddScoped<IRepository<ProductImage, int>, ProductImageRepository<ProductImage, int>>();

            //Services
            services.AddScoped<IService<Usuario, int>, UsuarioService<Usuario, int>>();
            services.AddScoped<IService<Product, int>, ProductService<Product, int>>();
            services.AddScoped<IService<Category, int>, CategoryService<Category, int>>();
            services.AddScoped<IService<ProductImage, int>, ProductImageService<ProductImage, int>>();
        }
    }
}