using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : CrudBaseController<Usuario, int>
    {
        public UsuarioController(IService<Usuario, int> service) : base(service) { }
    }
}