using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
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
                item.ViajeDetalles = _db.ViajeDetalles.Where(x => x.ViajId.Equals(item.ViajId)).ToList();
            }

            return viajes;
        }

        public Respuesta<object> InsertarViaje(ViajeDto viaje)
        {
            try
            {
                if(viaje.Admin)
                {
                    viaje.ViajTotalKm = viaje.ViajeDetalles.Select(x => x.VideDistancia).Sum();

                    if(viaje.ViajTotalKm > 100)
                        return Respuesta.Fault<object>("La distancia total no debe ser mayor a 100Km", "400");

                    List<ViajeDetalles> viajeDetalles = _db.ViajeDetalles.ToList();

                    foreach (var item in viaje.ViajeDetalles)
                    {
                        var repiteColaboradorPorDia = from vd in _db.ViajeDetalles
                                                      join v in _db.Viajes on vd.ViajId equals v.ViajId
                                                      where vd.ColId == item.ColId
                                                      && v.ViajFechaYHora.Date == viaje.ViajFechaYHora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<object>("Se repite", "400");
                    }

                    Viaje viajeAdd = new()
                    {
                        SucuId = viaje.SucuId,
                        TranId = viaje.TranId,
                        ViajEstado = viaje.ViajEstado,
                        ViajFechaCreacion = viaje.ViajFechaCreacion,
                        ViajFechaModificacion = viaje.ViajFechaModificacion,
                        ViajFechaYHora = viaje.ViajFechaYHora,
                        ViajTotalKm = viaje.ViajTotalKm,
                        ViajUsuaCreacion = viaje.ViajUsuaCreacion,
                        ViajUsuaModificacion = viaje.ViajUsuaModificacion
                    };

                    _db.Viajes.Add(viajeAdd);

                    viaje.ViajeDetalles.ForEach(item => item.ViajId = viajeAdd.ViajId);

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

        public Respuesta<object> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                var reporteEncabezado = from v in _db.Viajes
                                        where v.ViajFechaYHora.Date >= fechaInicio && v.ViajFechaYHora.Date <= fechaFinal
                                        select new { v.ViajId, v.SucuId, v.TranId, v.ViajTotalKm, TotalPagar = v.ViajTarifaActual * v.ViajTotalKm, v.ViajFechaYHora };

                return Respuesta.Success<object>(reporteEncabezado, "Operación exitosa", "200");
            } catch
            {
                return Respuesta.Fault<object>("Ha ocurrido un error, intente más tarde", "500");
            }
        }
    }
}
