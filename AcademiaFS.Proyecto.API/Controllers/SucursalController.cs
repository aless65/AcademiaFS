using AcademiaFS.Proyecto.API._Features.Sucursales;
using AcademiaFS.Proyecto.API._Features.Sucursales.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly SucursalService _sucursalService;

        public SucursalController(SucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalService.ListarSucursales();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(SucursaleDto sucursal)
        {
            var respuesta = _sucursalService.InsertarSucursales(sucursal);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(SucursaleDto sucursal)
        {
            var respuesta = _sucursalService.EditarSucursales(sucursal);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _sucursalService.EliminarSucursales(Id);

            return Ok(respuesta);
        }
    }
}
