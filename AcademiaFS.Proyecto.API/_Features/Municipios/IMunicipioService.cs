using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Municipios
{
    public interface IMunicipioService
    {
        Respuesta<List<MunicipioListarDto>> ListarMunicipios();
        Respuesta<MunicipioDto> InsertarMunicipios(MunicipioDto municipioDto);
        Respuesta<MunicipioDto> EditarMunicipios(MunicipioDto municipioDto);
        Respuesta<string> EliminarMunicipios(int Id);
    }
}
