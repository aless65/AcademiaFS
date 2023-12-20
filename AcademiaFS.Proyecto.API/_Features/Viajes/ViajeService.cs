using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcademiaFS.Proyecto.API._Features.Viajes
{
    public class ViajeService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ViajeService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
        }

        public List<Viaje> ListarViajes()
        {
            //List<Viaje> viajes = _unitOfWork.Repository<Viaje>().AsQueryable().ToList();

            List<Viaje> viajes = _unitOfWork.Repository<Viaje>()
                                                            .AsQueryable()
                                                            .Include(p => p.ViajesDetalles)
                                                            .ToList();

            //foreach (var item in viajes)
            //{
            //    item.ViajesDetalles = _unitOfWork.Repository<Viaje>().AsQueryable().Where(x => x.IdViaje.Equals(item.IdViaje)).ToList();
            //}

            return viajes;
        }

        public Respuesta<ViajeDto> InsertarViaje(ViajeDto viaje)
        {
            try
            {
                if(viaje.Admin)
                {
                    viaje.ViajTotalKm = viaje.ViajeDetalles.Select(x => x.DistanciaActual).Sum();

                    if(viaje.ViajTotalKm > 100)
                        return Respuesta.Fault<ViajeDto>("La distancia total no debe ser mayor a 100Km", "400");

                    List<ViajesDetalle> viajeDetalles = _unitOfWork.Repository<ViajesDetalle>().AsQueryable().ToList();

                    foreach (var item in viaje.ViajeDetalles)
                    {
                        var repiteColaboradorPorDia = from vd in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                      join v in _unitOfWork.Repository<Viaje>().AsQueryable() on vd.IdViaje equals v.IdViaje
                                                      where vd.IdColaborador == item.IdColaborador
                                                      && v.FechaYhora.Date == viaje.ViajFechaYHora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<ViajeDto>("Se repite", "400");
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

                    _unitOfWork.Repository<Viaje>().Add(viajeAdd);

                    viaje.ViajeDetalles.ForEach(item => item.IdViaje = viajeAdd.IdViaje);

                    _unitOfWork.Repository<ViajesDetalle>().AddRange(viaje.ViajeDetalles);

                    _unitOfWork.SaveChanges();

                    return Respuesta.Success<ViajeDto>(viaje, "Operación exitosa", "200");

                }
                else
                {
                    return Respuesta.Fault<ViajeDto>("Sólo los administradores pueden registrar viajes", "400");
                }
            }
            catch
            {
                return Respuesta.Fault<ViajeDto>("Intente más tarde", "500");
            }
        }

        public object ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                var reporteEncabezado = from v in _unitOfWork.Repository<Viaje>().AsQueryable()
                                        where v.FechaYhora.Date >= fechaInicio.Date && v.FechaYhora.Date <= fechaFinal.Date
                                        select new { v.IdViaje, v.IdSucursal, v.IdTransportista, v.TarifaActual,
                                                     v.TotalKm, TotalPagar = v.TarifaActual * v.TotalKm, 
                                                     v.FechaYhora, Detalles = _unitOfWork.Repository<ViajesDetalle>().Where(x => x.IdViaje == v.IdViaje).ToList()};

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
