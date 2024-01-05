using AcademiaFS.Proyecto.API._Features.Sucursales.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Sucursales
{
    public interface ISucursalService
    {
        Respuesta<List<SucursaleListarDto>> ListarSucursales();
        Respuesta<SucursaleDto> InsertarSucursales(SucursaleDto sucursalDto);
        Respuesta<SucursaleDto> EditarSucursales(SucursaleDto sucursalDto);
        Respuesta<string> EliminarSucursales(int Id);
    }
}
