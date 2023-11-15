using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : CrudBaseController<ProductImage, int>
    {
        public ProductImageController(IService<ProductImage, int> service) : base(service) { }
    }
}