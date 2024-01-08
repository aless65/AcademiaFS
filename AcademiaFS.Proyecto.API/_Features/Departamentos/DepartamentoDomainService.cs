using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Farsiman.Application.Core.Standard.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademiaFS.Proyecto.API._Features.Departamentos
{
    public class DepartamentoDomainService
    {
        public Respuesta<bool> ValidarDepartamentos(DepartamentoDto departamentoDto, List<Departamento> departamentos)
        {
            bool existe;

            if (departamentoDto.IdDepartamento < 1)
                existe = departamentos.Where(x => x.Codigo == departamentoDto.Codigo || x.Nombre == departamentoDto.Nombre).Any();
            else
                existe = departamentos.Where(x => (x.Codigo == departamentoDto.Codigo || x.Nombre == departamentoDto.Nombre) && x.IdDepartamento != departamentoDto.IdDepartamento).Any();

            if (existe)
                return Respuesta.Fault(Mensajes.REPETIDO("Departamento"), Codigos.BadRequest, false);
            else
                return Respuesta.Success(true);
        }
    }
}
