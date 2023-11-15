using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Auth([FromBody] AuthRequest auth)
        {
            try
            {
                return BuildResponse(await _service.Auth(auth));
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }
    }
}