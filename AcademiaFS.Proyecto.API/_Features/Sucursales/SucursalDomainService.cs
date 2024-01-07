using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Sucursales
{
    public class SucursalDomainService
    {
        public Respuesta<bool> ValidarSucursal(List<Sucursale> sucursales, SucursaleDto sucursal)
        {
            if (sucursales.Any(x => x.Nombre == sucursal.Nombre))
                return Respuesta.Fault(Mensajes.REPETIDO("Sucursal"), Codigos.BadRequest, false);

            return Respuesta.Success(true);
        }
    }
}
