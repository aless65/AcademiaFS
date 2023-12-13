using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
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
        public IActionResult Listar()
        {
            var respuesta = _colaboradorService.ListaColaboradores();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(tbColaboradores colaborador)
        {
            var respuesta = _colaboradorService.InsertarColaboradores(colaborador);

            return Ok(respuesta);
        }
    }
}
