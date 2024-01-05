using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public interface ITransportistaService
    {
        Respuesta<List<TransportistaListarDto>> ListarTransportistas();
        Respuesta<TransportistaDto> InsertarTransportistas(TransportistaDto transportistaDto);
        Respuesta<TransportistaDto> EditarTransportistas(TransportistaDto transportistaDto);
        Respuesta<string> EliminarTransportistas(int Id);
    }
}
