using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Usuario")]

    public class CategoryController : CrudBaseController<Category, int>
    {
        public CategoryController(IService<Category, int> service) : base(service) { }

    }
}