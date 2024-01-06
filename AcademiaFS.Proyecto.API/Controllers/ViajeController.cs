using AcademiaFS.Proyecto.API._Features.Viajes;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace AcademiaFS.Proyecto.API.Controllers
{
    //[Authorize]
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

        [HttpGet("Reporte/{fechaInicio}/{fechaFinal}/{transportista}")]
        public IActionResult Reporte(DateTime fechaInicio, DateTime fechaFinal, int transportista)
        {
            var respuesta = _viajeService.ReporteViajes(fechaInicio, fechaFinal, transportista);

            return Ok(respuesta);
        }
    }
}
