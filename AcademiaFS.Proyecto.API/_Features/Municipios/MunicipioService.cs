using Academia.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using AcademiaFS.Proyecto.API.Domain;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API._Features.Municipios
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;
        private readonly MunicipioDomainService _municipioDomainService;

        public MunicipioService(IMapper mapper, UnitOfWorkBuilder unitOfWorkBuilder, MunicipioDomainService municipioDomainService, CommonService commonService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorkBuilder.BuilderSistemaViajes();
            _municipioDomainService = municipioDomainService;
            _commonService = commonService;
        }

        public Respuesta<List<MunicipioListarDto>> ListarMunicipios()
        {
            var departamentos = (from muni in _unitOfWork.Repository<Municipio>().AsQueryable()
                                 join depa in _unitOfWork.Repository<Departamento>().AsQueryable()
                                 on muni.IdDepartamento equals depa.IdDepartamento
                                 where muni.Estado
                                 select new MunicipioListarDto
                                 {
                                     IdMunicipio = muni.IdMunicipio,
                                     Codigo = muni.Codigo,
                                     Nombre = muni.Nombre,
                                     IdDepartamento = depa.IdDepartamento,
                                     NombreDepartamento = depa.Nombre
                                 }).ToList();

            return Respuesta.Success<List<MunicipioListarDto>>(departamentos, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<MunicipioDto> InsertarMunicipios(MunicipioDto municipioDto)
        {
            try
            {
                List<Municipio> municipios = _unitOfWork.Repository<Municipio>().AsQueryable().ToList();

                municipioDto.IdMunicipio = 0;
                Respuesta<bool> validar = _municipioDomainService.ValidarMunicipios(municipioDto, municipios);

                if (!validar.Ok)
                    return Respuesta.Fault<MunicipioDto>(validar.Mensaje, validar.Codigo);

                Municipio municipio = _mapper.Map<Municipio>(municipioDto);
                municipio.UsuaCreacion = 1;
                municipio.FechaCreacion = DateTime.Now;

                MunicipioValidator validator = new MunicipioValidator();

                ValidationResult validationResult = validator.Validate(municipio);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<MunicipioDto>(menssageValidation, Codigos.BadRequest);
                }


                _unitOfWork.Repository<Municipio>().Add(municipio);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<MunicipioDto>(municipio), Mensajes.PROCESO_EXITOSO, Codigos.Success);

            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<MunicipioDto>(ex, "municipio");
            }
        }

        public Respuesta<MunicipioDto> EditarMunicipios(MunicipioDto municipioDto)
        {
            try
            {
                List<Municipio> municipios = _unitOfWork.Repository<Municipio>().AsQueryable().ToList();

                Respuesta<bool> validar = _municipioDomainService.ValidarMunicipios(municipioDto, municipios);

                if (!validar.Ok)
                    return Respuesta.Fault<MunicipioDto>(validar.Mensaje, validar.Codigo);

                var municipio = _mapper.Map<Municipio>(municipioDto);

                MunicipioValidator validator = new MunicipioValidator();

                ValidationResult validationResult = validator.Validate(municipio);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<MunicipioDto>(menssageValidation, Codigos.BadRequest);
                }

                var municipioAEditar = _unitOfWork.Repository<Municipio>().Where(x => x.IdMunicipio == municipio.IdMunicipio).FirstOrDefault();

                if (municipioAEditar != null)
                {
                    municipioAEditar.Codigo = municipio.Codigo;
                    municipioAEditar.Nombre = municipio.Nombre;
                    municipioAEditar.IdDepartamento = municipio.IdDepartamento;
                    municipioAEditar.UsuaModificacion = 1;
                    municipioAEditar.FechaModificacion = DateTime.Now;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<MunicipioDto>(municipioAEditar), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<MunicipioDto>(ex, "municipio");
            }
        }

        public Respuesta<string> EliminarMunicipios(int Id)
        {
            try
            {
                var municipioAEliminar = _unitOfWork.Repository<Municipio>().Where(x => x.IdMunicipio == Id).FirstOrDefault();

                if (municipioAEliminar != null)
                    municipioAEliminar.Estado = false;

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
