using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : CrudBaseController<Product, int>
    {
        public ProductController(IService<Product, int> service) : base(service) { }
    }
}