using AcademiaFS.Proyecto.API._Features.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var respuesta = _authService.Login(username, password);

            return Ok(respuesta);
        }
    }
}
