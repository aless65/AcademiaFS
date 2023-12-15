using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Viajes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;

namespace AcademiaFS.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly ViajeService _viajeService;

        public ViajeController(ViajeService viajeService)
        {
            _viajeService = viajeService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _viajeService.ListarViajes();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(ViajeDto viaje)
        {
            var respuesta = _viajeService.InsertarViaje(viaje);

            return Ok(respuesta);
        }

        [HttpGet("Reporte/{fechaInicio}/{fechaFinal}")]
        public IActionResult Reporte(DateTime fechaInicio, DateTime fechaFinal)
        {
            var respuesta = _viajeService.ReporteViajes(fechaInicio, fechaFinal);

            return Ok(respuesta);
        }
    }
}
