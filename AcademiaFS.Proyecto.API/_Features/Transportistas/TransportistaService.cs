using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.Repositories;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportistaService(IMapper mapper, UnitOfWorkBuilder unitOfWorkBuilder)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorkBuilder.BuilderSistemaViajes();
        }

        public Respuesta<List<TransportistaAuditoriaDto>> ListarTransportistas()
        {
            var transportistas = (from transportista in _unitOfWork.Repository<Transportista>().AsQueryable()
                                  join usuarioCrea in _unitOfWork.Repository<Usuario>().AsQueryable()
                                  on transportista.UsuaCreacion equals usuarioCrea.IdUsuario
                                  join usuarioModifica in _unitOfWork.Repository<Usuario>().AsQueryable()
                                  on transportista.UsuaModificacion equals usuarioModifica.IdUsuario into umGroup
                                  from usuarioModifica in umGroup.DefaultIfEmpty()
                                  where transportista.Estado
                                  select new TransportistaAuditoriaDto
                                  {
                                      IdTransportista = transportista.IdTransportista,
                                      Nombres = transportista.Nombres,
                                      Apellidos = transportista.Apellidos,
                                      Identidad = transportista.Identidad,
                                      TarifaKm = transportista.TarifaKm,
                                      FechaNacimiento = transportista.FechaNacimiento,
                                      Sexo = transportista.Sexo,
                                      UsuaCreacion = transportista.UsuaCreacion,
                                      UsuaCreacionNombre = usuarioCrea.Nombre,
                                      FechaCreacion = transportista.FechaCreacion,
                                      UsuaModificacion = transportista.UsuaModificacion,
                                      UsuaModificacionNombre = usuarioModifica.Nombre,
                                      FechaModificacion = transportista.FechaModificacion
                                  }).ToList();

            return Respuesta.Success<List<TransportistaAuditoriaDto>>(transportistas, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<TransportistaDto> InsertarTransportistas(TransportistaDto transportistaDto)
        {
            try
            {
                var transportista = _mapper.Map<Transportista>(transportistaDto);
                transportista.UsuaCreacion = 1;
                transportista.FechaCreacion = DateTime.Now;

                _unitOfWork.Repository<Transportista>().Add(transportista);
                _unitOfWork.SaveChanges();
                transportistaDto.IdTransportista = transportista.IdTransportista;

                return Respuesta.Success(_mapper.Map<TransportistaDto>(transportista), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<TransportistaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<TransportistaDto> EditarTransportistas(TransportistaDto transportista)
        {
            try
            {
                var transportistaAEditar = _unitOfWork.Repository<Transportista>().Where(x => x.IdTransportista == transportista.IdTransportista).FirstOrDefault();

                if (transportista != null)
                {
                    transportistaAEditar.Nombres = transportista.Nombres;
                    transportistaAEditar.Apellidos = transportista.Apellidos;
                    transportistaAEditar.Identidad = transportista.Identidad;
                    transportistaAEditar.TarifaKm = transportista.TarifaKm;
                    transportistaAEditar.UsuaModificacion = 1;
                    transportistaAEditar.FechaModificacion = DateTime.Now;

                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<TransportistaDto>(transportistaAEditar), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<TransportistaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<string> EliminarTransportistas(int Id)
        {
            try
            {
                var transportistaAEliminar = _unitOfWork.Repository<Transportista>().Where(x => x.IdTransportista == Id).FirstOrDefault();

                transportistaAEliminar.Estado = false;

                _unitOfWork.SaveChanges();


                return Respuesta.Success<string>(Mensajes.PROCESO_EXITOSO, Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<string>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
    }
}
