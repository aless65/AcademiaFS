using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API.Domain;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.Repositories;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainService _domainService;

        public TransportistaService(IMapper mapper, UnitOfWorkBuilder unitOfWorkBuilder, DomainService domainService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorkBuilder.BuilderSistemaViajes();
            _domainService = domainService;
        }

        public Respuesta<List<TransportistaListarDto>> ListarTransportistas()
        {
            var transportistas = (from transportista in _unitOfWork.Repository<Transportista>().AsQueryable()
                                  where transportista.Estado
                                  select new TransportistaListarDto
                                  {
                                      IdTransportista = transportista.IdTransportista,
                                      Nombres = transportista.Nombres,
                                      Apellidos = transportista.Apellidos,
                                      Identidad = transportista.Identidad,
                                      TarifaKm = transportista.TarifaKm,
                                      FechaNacimiento = transportista.FechaNacimiento,
                                      Sexo = transportista.Sexo
                                  }).ToList();

            return Respuesta.Success<List<TransportistaListarDto>>(transportistas, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<TransportistaDto> InsertarTransportistas(TransportistaDto transportistaDto)
        {
            try
            {
                if (_domainService.TransportistaExiste(transportistaDto.Identidad))
                    return Respuesta.Fault<TransportistaDto>(Mensajes.REPETIDO("Transportista"), Codigos.Error);

                var transportista = _mapper.Map<Transportista>(transportistaDto);
                transportista.UsuaCreacion = 1;
                transportista.FechaCreacion = DateTime.Now;

                TransportistaValidator validator = new TransportistaValidator();

                ValidationResult validationResult = validator.Validate(transportista);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<TransportistaDto>(menssageValidation, Codigos.BadRequest);
                }

                _unitOfWork.Repository<Transportista>().Add(transportista);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<TransportistaDto>(transportista), Mensajes.PROCESO_EXITOSO, Codigos.Success);
                
            }
            catch (Exception ex)
            {
                return Respuesta.Fault<TransportistaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<TransportistaDto> EditarTransportistas(TransportistaDto transportistaDto)
        {
            try
            {
                var transportista = _mapper.Map<Transportista>(transportistaDto);

                TransportistaValidator validator = new TransportistaValidator();

                ValidationResult validationResult = validator.Validate(transportista);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<TransportistaDto>(menssageValidation, Codigos.BadRequest);
                }

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
            catch (Exception ex)
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

        //private bool TransportistaExiste(string identidad)
        //{
        //    bool existe = _unitOfWork.Repository<Transportista>().Where(x => x.Identidad == identidad).Any();

        //    return existe;
        //}
    }
}
