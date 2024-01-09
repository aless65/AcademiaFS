using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados;
using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.EjemploUT2_Planillas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpPost("ObtenerPlanilla")]
        public IActionResult GetPlanilla(EmpleadoDto empleadoDto)
        {
            var respuesta = _empleadoService.ObtenerPlanilla(empleadoDto);

            return Ok(respuesta);
        }
    }
}
