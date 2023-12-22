using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorService _colaboradorService;

        public ColaboradorController(ColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _colaboradorService.ListaColaboradores();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(ColaboradoreDto colaborador)
        {
            var respuesta = _colaboradorService.InsertarColaboradores(colaborador);

            return Ok(respuesta);
        }
    }
}
