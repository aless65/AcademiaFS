//using AcademiaFS.Proyecto.API._Common.Entities;
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
using Farsiman.Infraestructure.Core.Entity.Standard;
using AcademiaFS.Proyecto.API.Domain;

namespace AcademiaFS.Proyecto.API._Features.Viajes
{
    public class ViajeService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainService _domainService;

        public ViajeService(UnitOfWorkBuilder unitOfWork, IMapper mapper, DomainService validacionesDomain)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
            _domainService = validacionesDomain;
        }

        public Respuesta<List<ViajeListarDto>> ListarViajes()
        {

            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join tran in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on viaje.IdTransportista equals tran.IdTransportista
                              join sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
                              on viaje.IdSucursal equals sucu.IdSucursal
                              where viaje.Estado == true
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

        public Respuesta<ViajeListarDto> InsertarViaje(ViajeDto viajeDto)
        {
            try
            {
                if(viajeDto.Admin)
                {
                    if(!_domainService.SucursalExiste(viajeDto.IdSucursal))
                        return Respuesta.Fault<ViajeListarDto>(Mensajes.NO_EXISTE("Sucursal"), Codigos.Error);

                    if (!_domainService.TransportistaExisteId(viajeDto.IdTransportista))
                        return Respuesta.Fault<ViajeListarDto>(Mensajes.NO_EXISTE("Transportista"), Codigos.Error);

                    var viaje = _mapper.Map<Viaje>(viajeDto);
                    viaje.UsuaCreacion = 1;
                    viaje.FechaCreacion = DateTime.Now;

                    viaje.TotalKm = viaje.ViajesDetalles.Select(x => x.DistanciaActual).Sum();

                    if (viaje.ViajesDetalles.Select(g => g.IdColaborador).Count() !=
                    viaje.ViajesDetalles.Select(g => g.IdColaborador).Distinct().Count())
                        return Respuesta.Fault<ViajeListarDto>("No puede ingresar dos veces el mismo colaborador", Codigos.BadRequest);

                    if (viaje.TotalKm > 100)
                        return Respuesta.Fault<ViajeListarDto>("La distancia total no debe ser mayor a 100Km", Codigos.BadRequest);

                    viaje.TarifaActual = (from tran in _unitOfWork.Repository<Transportista>().AsQueryable()
                                          where tran.IdTransportista == viaje.IdTransportista
                                          select tran.TarifaKm).FirstOrDefault();

                    foreach (var item in viaje.ViajesDetalles)
                    {
                        if (!_domainService.ColaboradorExisteId(item.IdColaborador))
                            return Respuesta.Fault<ViajeListarDto>(Mensajes.NO_EXISTE("Colaborador"), Codigos.Error);

                        var repiteColaboradorPorDia = from vd in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                                                      join v in _unitOfWork.Repository<Viaje>().AsQueryable() on vd.IdViaje equals v.IdViaje
                                                      where vd.IdColaborador == item.IdColaborador
                                                      && v.FechaYhora.Date == viaje.FechaYhora.Date
                                                      select vd;

                        if (repiteColaboradorPorDia.Count() > 0)
                            return Respuesta.Fault<ViajeListarDto>("Uno de los colaboradores ya tiene un viaje en esa fecha", Codigos.BadRequest);
                        else
                        {
                            item.DistanciaActual = (from colab in _unitOfWork.Repository<Colaboradore>().AsQueryable()
                                                    join colabXsucu in _unitOfWork.Repository<SucursalesXcolaboradore>().AsQueryable()
                                                    on colab.IdColaborador equals colabXsucu.IdColaborador
                                                    where colab.IdColaborador == item.IdColaborador 
                                                    && colabXsucu.IdSucursal == viaje.IdSucursal
                                                    select colabXsucu.DistanciaKm).FirstOrDefault();

                            viaje.TotalKm += item.DistanciaActual;

                            item.UsuaCreacion = viaje.UsuaCreacion;
                            item.FechaCreacion = DateTime.Now;
                        }
                    }

                    _unitOfWork.Repository<Viaje>().Add(viaje);

                    _unitOfWork.SaveChanges();

                    return Respuesta.Success(_mapper.Map<ViajeListarDto>(_unitOfWork.Repository<Viaje>().Where(x => x.IdViaje == viaje.IdViaje).FirstOrDefault()), Mensajes.PROCESO_EXITOSO, Codigos.Success);

                }
                else
                {
                    return Respuesta.Fault<ViajeListarDto>("Sólo los administradores pueden registrar viajes", Codigos.Unauthorized);
                }
            }
            catch(Exception ex) 
            {
                return _domainService.ValidacionCambiosBase<ViajeListarDto>(ex);
            }
        }

        public Respuesta<ViajeReporteRangoFechaDto> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal, int transportista)
        {
            try
            {
                var reporteEncabezado = from v in _unitOfWork.Repository<Viaje>().AsQueryable()
                                        join tran in _unitOfWork.Repository<Transportista>().AsQueryable()
                                        on v.IdTransportista equals tran.IdTransportista
                                        join sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                        on v.IdSucursal equals sucu.IdSucursal
                                        where v.FechaYhora.Date >= fechaInicio.Date && v.FechaYhora.Date <= fechaFinal.Date && v.IdTransportista == transportista
                                        select new ViajeListarDto 
                                        { IdViaje = v.IdViaje, 
                                          IdSucursal = v.IdSucursal, 
                                          NombreSucursal = sucu.Nombre,
                                          IdTransportista = v.IdTransportista, 
                                          NombreTransportista = $"{tran.Nombres} {tran.Apellidos}",
                                          TarifaActual = v.TarifaActual,
                                          TotalKm = v.TotalKm, 
                                          TotalPagar = v.TarifaActual * v.TotalKm, 
                                          FechaYhora = v.FechaYhora,
                                          ViajesDetalles = _mapper.Map<List<ViajesDetalleListarDto>>(v.ViajesDetalles)
                                        };

                var totalAPagar = reporteEncabezado.Sum(v => v.TotalPagar);

                ViajeReporteRangoFechaDto reporteTotal = new ViajeReporteRangoFechaDto
                {
                    totalAPagar = totalAPagar,
                    reporte = reporteEncabezado
                };

                return Respuesta.Success(reporteTotal, Mensajes.PROCESO_EXITOSO, Codigos.Success);
            } catch
            {
                return Respuesta.Fault<ViajeReporteRangoFechaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
    }
}
