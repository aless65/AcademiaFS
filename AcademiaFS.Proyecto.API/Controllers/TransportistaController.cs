using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.API.Controllers
{
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
        public IActionResult Insertar(Transportista transportista)
        {
            var respuesta = _transportistaService.InsertarTransportistas(transportista);

            return Ok(respuesta);
        }
    }
}
