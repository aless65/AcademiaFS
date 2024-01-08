using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Farsiman.Application.Core.Standard.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademiaFS.Proyecto.API._Features.Municipios
{
    public class MunicipioDomainService
    {
        public Respuesta<bool> ValidarMunicipios(MunicipioDto municipio, List<Municipio> municipios)
        {
            bool existe;

            if (municipio.IdMunicipio < 1)
                existe = municipios.Where(x => x.Nombre == municipio.Nombre && x.IdDepartamento == municipio.IdDepartamento || x.Codigo == municipio.Codigo).Any();
            else
                existe = municipios.Where(x => (x.Nombre == municipio.Nombre && x.IdDepartamento == municipio.IdDepartamento || x.Codigo == municipio.Codigo) && x.IdMunicipio != municipio.IdMunicipio).Any();

            if (existe)
                return Respuesta.Fault(Mensajes.REPETIDO("Municipio"), Codigos.BadRequest, false);
            else
                return Respuesta.Success(true);
        }
    }
}
