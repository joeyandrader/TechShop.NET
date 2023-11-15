using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : CrudBaseController<Product, int>
    {
        public ProductImageController(IService<Product, int> service) : base(service) { }
    }
}