using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores
{
    public interface IColaboradorService
    {
        Respuesta<List<ColaboradoreListarDto>> ListaColaboradores();
        Respuesta<ColaboradoreDto> InsertarColaboradores(ColaboradoreDto colaboradoresDto);

    }
}
