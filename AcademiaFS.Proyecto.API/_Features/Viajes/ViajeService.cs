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


            return Respuesta.Success(viajesList, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<ViajeDto> InsertarViaje(ViajeDto viajeDto)
        {
            try
            {
                if(viajeDto.Admin)
                {
                    var viaje = _mapper.Map<Viaje>(viajeDto);
                    viaje.UsuaCreacion = 1;
                    viaje.FechaCreacion = DateTime.Now;

                    viaje.TotalKm = viaje.ViajesDetalles.Select(x => x.DistanciaActual).Sum();

                    if(viaje.TotalKm > 100)
                        return Respuesta.Fault<ViajeDto>("La distancia total no debe ser mayor a 100Km", Codigos.BadRequest);

                    List<ViajesDetalle> viajeDetalles = _unitOfWork.Repository<ViajesDetalle>().AsQueryable().ToList();

                    foreach (var item in viaje.ViajesDetalles)
                    {
                        var repiteColaboradorPorDia = from vd in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                      join v in _unitOfWork.Repository<Viaje>().AsQueryable() on vd.IdViaje equals v.IdViaje
                                                      where vd.IdColaborador == item.IdColaborador
                                                      && v.FechaYhora.Date == viaje.FechaYhora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<ViajeDto>("Se repite", Codigos.BadRequest);
                        else
                        {
                            item.UsuaCreacion = viaje.UsuaCreacion;
                            item.FechaCreacion = DateTime.Now;
                        }
                    }

                    _unitOfWork.Repository<Viaje>().Add(viaje);

                    _unitOfWork.SaveChanges();

                    return Respuesta.Success(_mapper.Map<ViajeDto>(viaje), Mensajes.PROCESO_EXITOSO, Codigos.Success);

                }
                else
                {
                    return Respuesta.Fault<ViajeDto>("Sólo los administradores pueden registrar viajes", Codigos.Unauthorized);
                }
            }
            catch(Exception ex) 
            {
                if (ex.Message.Contains("saving the entity changes"))
                    return Respuesta.Fault<ViajeDto>(Mensajes.DATOS_INCORRECTOS, Codigos.BadRequest);
                else
                    return Respuesta.Fault<ViajeDto>("Intente más tarde", Codigos.Error);
            }
        }

        public Respuesta<ViajeReporteRangoFechaDto> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                var reporteEncabezado = from v in _unitOfWork.Repository<Viaje>().AsQueryable()
                                        where v.FechaYhora.Date >= fechaInicio.Date && v.FechaYhora.Date <= fechaFinal.Date
                                        select new ViajeListarDto 
                                        { IdViaje = v.IdViaje, 
                                          IdSucursal = v.IdSucursal, 
                                          IdTransportista = v.IdTransportista, 
                                          TarifaActual = v.TarifaActual,
                                          TotalKm = v.TotalKm, 
                                          TotalPagar = v.TarifaActual * v.TotalKm, 
                                          FechaYhora = v.FechaYhora, 
                                          //ViajesDetalles = _mapper.Map<ViajeListarDetalleDto>(_unitOfWork.Repository<ViajesDetalle>().Where(x => x.IdViaje == v.IdViaje).ToList())
                                        };

                var totalAPagar = reporteEncabezado.Sum(v => v.TotalPagar);

                ViajeReporteRangoFechaDto reporteTotal = new ViajeReporteRangoFechaDto
                {
                    totalAPagar = totalAPagar,
                    reporte = reporteEncabezado
                };

                return Respuesta.Success<ViajeReporteRangoFechaDto>(reporteTotal, Mensajes.PROCESO_EXITOSO, Codigos.Success);
            } catch
            {
                return Respuesta.Fault<ViajeReporteRangoFechaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
    }
}
