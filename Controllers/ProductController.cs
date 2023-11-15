using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]

    public class ProductController : CrudBaseController<Product, int>
    {
        private readonly IService<Product, int> _product;
        public ProductController(IService<Product, int> service, IService<Product, int> product) : base(service)
        {
            _product = product;
        }
    }

}