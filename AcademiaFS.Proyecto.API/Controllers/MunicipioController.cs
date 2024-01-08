using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using AcademiaFS.Proyecto.API._Features.Departamentos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.Proyecto.API._Features.Municipios;
using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using Microsoft.AspNetCore.Authorization;

namespace AcademiaFS.Proyecto.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService _municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _municipioService.ListarMunicipios();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(MunicipioDto municipio)
        {
            var respuesta = _municipioService.InsertarMunicipios(municipio);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(MunicipioDto municipio)
        {
            var respuesta = _municipioService.EditarMunicipios(municipio);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _municipioService.EliminarMunicipios(Id);

            return Ok(respuesta);
        }
    }
}
