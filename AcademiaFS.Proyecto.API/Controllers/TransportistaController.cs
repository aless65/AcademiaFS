using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController : ControllerBase
    {
        private readonly TransportistaService _transportistaService;

        public TransportistaController(TransportistaService transportistaService)
        {
            _transportistaService = transportistaService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _transportistaService.ListarTransportistas();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(TransportistaDto transportista)
        {
            var respuesta = _transportistaService.InsertarTransportistas(transportista);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Editar(TransportistaDto transportista)
        {
            var respuesta = _transportistaService.EditarTransportistas(transportista);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _transportistaService.EliminarTransportistas(Id);

            return Ok(respuesta);
        }
    }
}
