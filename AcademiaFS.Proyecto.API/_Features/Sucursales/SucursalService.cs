using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.API.Domain;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using FluentValidation.Results;

namespace AcademiaFS.Proyecto.API._Features.Sucursales
{
    public class SucursalService : ISucursalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainService _domainService;
        private readonly SucursalDomainService _sucursalDomainService;

        public SucursalService(UnitOfWorkBuilder unitOfWork, IMapper mapper, DomainService domainService, SucursalDomainService sucursalDomainService)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
            _domainService = domainService;
            _sucursalDomainService = sucursalDomainService;
        }

        public Respuesta<List<SucursaleListarDto>> ListarSucursales()
        {
            var listado = (from sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
                           join muni in _unitOfWork.Repository<Municipio>().AsQueryable()
                           on sucu.IdMunicipio equals muni.IdMunicipio
                           where sucu.Estado == true
                           select new SucursaleListarDto 
                           {
                               IdSucursal = sucu.IdSucursal,
                               Nombre = sucu.Nombre,
                               Direccion = sucu.Direccion,
                               IdMunicipio = muni.IdMunicipio,
                               NombreMunicipio = muni.Nombre
                           }).ToList();

            return Respuesta.Success(listado, "Bien", "200");
        }

        public Respuesta<SucursaleDto> InsertarSucursales(SucursaleDto sucursalDto)
        {
            try
            {
                var sucursalesListado = _unitOfWork.Repository<Sucursale>().AsQueryable().ToList();

                Respuesta<bool> validar = _sucursalDomainService.ValidarSucursal(sucursalesListado, sucursalDto);

                if (!validar.Ok)
                    return Respuesta.Fault<SucursaleDto>(validar.Mensaje, validar.Codigo);

                var sucursal = _mapper.Map<Sucursale>(sucursalDto);
                sucursal.UsuaCreacion = 1;
                sucursal.FechaCreacion = DateTime.Now;

                SucursaleValidator validator = new SucursaleValidator();

                ValidationResult validationResult = validator.Validate(sucursal);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<SucursaleDto>(menssageValidation, Codigos.BadRequest);
                }

                _unitOfWork.Repository<Sucursale>().Add(sucursal);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<SucursaleDto>(sucursal), Mensajes.PROCESO_EXITOSO, Codigos.Success);

            }
            catch 
            {
                return Respuesta.Fault<SucursaleDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<SucursaleDto> EditarSucursales(SucursaleDto sucursalDto)
        {
            try
            {
                if (_unitOfWork.Repository<Sucursale>().Where(x => x.Nombre == sucursalDto.Nombre && x.IdSucursal != sucursalDto.IdSucursal).Any())
                    return Respuesta.Fault<SucursaleDto>(Mensajes.REPETIDO("Sucursal"), Codigos.Error);

                var sucursal = _mapper.Map<Sucursale>(sucursalDto);

                SucursaleValidator validator = new SucursaleValidator();

                ValidationResult validationResult = validator.Validate(sucursal);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<SucursaleDto>(menssageValidation, Codigos.BadRequest);
                }

                var sucursalAEditar = _unitOfWork.Repository<Sucursale>().Where(x => x.IdSucursal == sucursal.IdSucursal).FirstOrDefault();

                if (sucursalAEditar != null)
                {
                    sucursalAEditar.Nombre = sucursal.Nombre;
                    sucursalAEditar.Direccion = sucursal.Direccion;
                    sucursalAEditar.IdMunicipio = sucursal.IdMunicipio;
                    sucursalAEditar.UsuaModificacion = 1;
                    sucursalAEditar.FechaModificacion = DateTime.Now;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<SucursaleDto>(sucursalAEditar), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch 
            {
                return Respuesta.Fault<SucursaleDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<string> EliminarSucursales(int Id)
        {
            try
            {
                var sucursalAEliminar = _unitOfWork.Repository<Sucursale>().Where(x => x.IdSucursal == Id).FirstOrDefault();

                if (sucursalAEliminar != null)
                    sucursalAEliminar.Estado = false;

                _unitOfWork.SaveChanges();


                return Respuesta.Success("", Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<string>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
    }
}
