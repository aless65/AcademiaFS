using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Viajes
{
    public interface IViajeService
    {
        Respuesta<List<ViajeListarDto>> ListarViajes();
        Respuesta<ViajeListarDto> InsertarViaje(ViajeDto viajeDto);
        Respuesta<ViajeReporteRangoFechaDto> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal, int transportista);
    }
}
