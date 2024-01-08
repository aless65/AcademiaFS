using AcademiaFS.Proyecto.API._Features.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //[HttpPost("Login/{username}/{password}")]
        //public IActionResult Login(string username, string password)
        //{
        //    var respuesta = _usuarioService.Login(username, password);

        //    return Ok(respuesta);
        //}
    }
}
