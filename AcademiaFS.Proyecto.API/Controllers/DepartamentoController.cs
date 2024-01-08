using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.Proyecto.API._Features.Departamentos;
using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using Microsoft.AspNetCore.Authorization;

namespace AcademiaFS.Proyecto.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _departamentoService.ListarDepartamentos();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(DepartamentoDto departamento)
        {
            var respuesta = _departamentoService.InsertarDepartamentos(departamento);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(DepartamentoDto departamento)
        {
            var respuesta = _departamentoService.EditarDepartamentos(departamento);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _departamentoService.EliminarDepartamentos(Id);

            return Ok(respuesta);
        }
    }
}
