using AcademiaFS.Proyecto.API._Common.Entities;
using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
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

        public Respuesta<List<ViajeListarDto>> ListarViajes()
        {
            //var viajes = (from viajes in _unitOfWork.Repository<ViajeDto>);

            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join tran in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on viaje.IdTransportista equals tran.IdTransportista
                              join sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
                              on viaje.IdSucursal equals sucu.IdSucursal
                              select new ViajeListarDto
                              {
                                  IdViaje = viaje.IdViaje,
                                  FechaYhora = viaje.FechaYhora,
                                  IdSucursal = viaje.IdSucursal,
                                  NombreSucursal = sucu.Nombre,
                                  IdTransportista = viaje.IdTransportista,
                                  NombreTransportista = $"{tran.Nombres} {tran.Apellidos}",
                                  TarifaActual = viaje.TarifaActual,
                                  TotalKm = viaje.TotalKm,
                                  ViajesDetalles = (from detalles in viaje.ViajesDetalles.AsQueryable()
                                                    join colab in _unitOfWork.Repository<Colaboradore>().AsQueryable()
                                                    on detalles.IdColaborador equals colab.IdColaborador
                                                    select new ViajesDetalleListarDto
                                                    {
                                                        IdViajeDetalle = detalles.IdViajeDetalle,
                                                        IdViaje = detalles.IdViaje,
                                                        IdColaborador = colab.IdColaborador,
                                                        ColaboradorNombre = colab.Nombres,
                                                        DistanciaActual = detalles.DistanciaActual
                                                    }).ToList()
                              }).ToList();  

            //List<Viaje> viajes = _unitOfWork.Repository<Viaje>()
            //                                                .AsQueryable()
            //                                                .Include(p => p.ViajesDetalles)
            //                                                .ToList();

            return Respuesta.Success(viajesList, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<ViajeDto> InsertarViaje(ViajeDto viaje)
        {
            try
            {
                if(viaje.Admin)
                {
                    viaje.TotalKm = viaje.ViajesDetalles.Select(x => x.DistanciaActual).Sum();

                    if(viaje.TotalKm > 100)
                        return Respuesta.Fault<ViajeDto>("La distancia total no debe ser mayor a 100Km", "400");

                    List<ViajesDetalle> viajeDetalles = _unitOfWork.Repository<ViajesDetalle>().AsQueryable().ToList();

                    foreach (var item in viaje.ViajesDetalles)
                    {
                        var repiteColaboradorPorDia = from vd in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                      join v in _unitOfWork.Repository<Viaje>().AsQueryable() on vd.IdViaje equals v.IdViaje
                                                      where vd.IdColaborador == item.IdColaborador
                                                      && v.FechaYhora.Date == viaje.FechaYhora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<ViajeDto>("Se repite", "400");
                    }

                    Viaje viajeAdd = new()
                    {
                        IdSucursal = viaje.IdSucursal,
                        IdTransportista = viaje.IdTransportista,
                        FechaYhora = viaje.FechaYhora,
                        TotalKm = viaje.TotalKm,
                        TarifaActual = viaje.TarifaActual,
                    };

                    _unitOfWork.Repository<Viaje>().Add(viajeAdd);

                    //viaje.ViajeDetalles.ForEach(item => item.IdViaje = viajeAdd.IdViaje);

                    //_unitOfWork.Repository<ViajesDetalle>().AddRange(viaje.ViajeDetalles);

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
