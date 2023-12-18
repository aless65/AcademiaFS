using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using Farsiman.Application.Core.Standard.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcademiaFS.Proyecto.API._Features.Viajes
{
    public class ViajeService
    {
        private readonly SistemaViajesDBContext _db;

        public ViajeService(SistemaViajesDBContext db)
        {
            _db = db;
        }   

        public List<Viaje> ListarViajes()
        {
            List<Viaje> viajes = _db.Viajes.ToList();

            foreach (var item in viajes)
            {
                item.ViajesDetalles = _db.ViajeDetalles.Where(x => x.IdViaje.Equals(item.IdViaje)).ToList();
            }

            return viajes;
        }

        public Respuesta<object> InsertarViaje(ViajeDto viaje)
        {
            try
            {
                if(viaje.Admin)
                {
                    viaje.ViajTotalKm = viaje.ViajeDetalles.Select(x => x.DistanciaActual).Sum();

                    if(viaje.ViajTotalKm > 100)
                        return Respuesta.Fault<object>("La distancia total no debe ser mayor a 100Km", "400");

                    List<ViajesDetalle> viajeDetalles = _db.ViajeDetalles.ToList();

                    foreach (var item in viaje.ViajeDetalles)
                    {
                        var repiteColaboradorPorDia = from vd in _db.ViajeDetalles
                                                      join v in _db.Viajes on vd.IdViaje equals v.IdViaje
                                                      where vd.IdColaborador == item.IdColaborador
                                                      && v.FechaYhora.Date == viaje.ViajFechaYHora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<object>("Se repite", "400");
                    }

                    Viaje viajeAdd = new()
                    {
                        IdSucursal = viaje.SucuId,
                        IdTransportista = viaje.TranId,
                        Estado = viaje.ViajEstado,
                        FechaCreacion = viaje.ViajFechaCreacion,
                        FechaModificacion = viaje.ViajFechaModificacion,
                        FechaYhora = viaje.ViajFechaYHora,
                        TotalKm = viaje.ViajTotalKm,
                        TarifaActual = viaje.ViajTarifaActual,
                        UsuaCreacion = viaje.ViajUsuaCreacion,
                        UsuaModificacion = viaje.ViajUsuaModificacion
                    };

                    _db.Viajes.Add(viajeAdd);

                    viaje.ViajeDetalles.ForEach(item => item.IdViaje = viajeAdd.IdViaje);

                    _db.ViajeDetalles.AddRange(viaje.ViajeDetalles);

                    _db.SaveChanges();

                    return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");

                }
                else
                {
                    return Respuesta.Fault<object>("Sólo los administradores pueden registrar viajes", "400");
                }
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }

        public object ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                var reporteEncabezado = from v in _db.Viajes
                                        where v.FechaYhora.Date >= fechaInicio.Date && v.FechaYhora.Date <= fechaFinal.Date
                                        select new { v.IdViaje, v.IdSucursal, v.IdTransportista, v.TarifaActual,
                                                     v.TotalKm, TotalPagar = v.TarifaActual * v.TotalKm, 
                                                     v.FechaYhora, Detalles = _db.ViajeDetalles.Where(x => x.IdViaje == v.IdViaje).ToList()};

                var totalAPagar = reporteEncabezado.Sum(v => v.TotalPagar);

                var reporteConTotal = new
                {
                    totalAPagar = totalAPagar,
                    reporte = reporteEncabezado
                };

                return reporteConTotal;
            } catch
            {
                return null;
            }
        }
    }
}
