using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Departamentos
{
    public interface IDepartamentoService
    {
        Respuesta<List<DepartamentoDto>> ListarDepartamentos();
        Respuesta<DepartamentoDto> InsertarDepartamentos(DepartamentoDto departamentoDto);
        Respuesta<DepartamentoDto> EditarDepartamentos(DepartamentoDto departamentoDto);
        Respuesta<string> EliminarDepartamentos(int Id);
    }
}
