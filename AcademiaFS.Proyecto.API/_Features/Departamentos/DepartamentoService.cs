using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using AcademiaFS.Proyecto.API._Features.Municipios;
using AcademiaFS.Proyecto.API.Domain;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using FluentValidation.Results;

namespace AcademiaFS.Proyecto.API._Features.Departamentos
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DepartamentoDomainService _departamentoDomainService;

        public DepartamentoService(IMapper mapper, UnitOfWorkBuilder unitOfWorkBuilder, DepartamentoDomainService departamentoDomainService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorkBuilder.BuilderSistemaViajes();
            _departamentoDomainService = departamentoDomainService;
        }

        public Respuesta<List<DepartamentoDto>> ListarDepartamentos()
        {
            var departamentos = (from departamento in _unitOfWork.Repository<Departamento>().AsQueryable()
                                  where departamento.Estado
                                  select new DepartamentoDto
                                  {
                                      IdDepartamento = departamento.IdDepartamento,
                                      Codigo = departamento.Codigo,
                                      Nombre = departamento.Nombre
                                  }).ToList();

            return Respuesta.Success<List<DepartamentoDto>>(departamentos, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<DepartamentoDto> InsertarDepartamentos(DepartamentoDto departamentoDto)
        {
            try
            {
                List<Departamento> departamentos = _unitOfWork.Repository<Departamento>().AsQueryable().ToList();
                departamentoDto.IdDepartamento = 0;
                Respuesta<bool> validar = _departamentoDomainService.ValidarDepartamentos(departamentoDto, departamentos);

                if (!validar.Ok)
                    return Respuesta.Fault<DepartamentoDto>(validar.Mensaje, validar.Codigo);

                var departamento = _mapper.Map<Departamento>(departamentoDto);
                departamento.UsuaCreacion = 1;
                departamento.FechaCreacion = DateTime.Now;

                DepartamentoValidator validator = new DepartamentoValidator();

                ValidationResult validationResult = validator.Validate(departamento);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<DepartamentoDto>(menssageValidation, Codigos.BadRequest);
                }

                _unitOfWork.Repository<Departamento>().Add(departamento);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<DepartamentoDto>(departamento), Mensajes.PROCESO_EXITOSO, Codigos.Success);

            }
            catch 
            {
                return Respuesta.Fault<DepartamentoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<DepartamentoDto> EditarDepartamentos(DepartamentoDto departamentoDto)
        {
            try
            {
                List<Departamento> departamentos = _unitOfWork.Repository<Departamento>().AsQueryable().ToList();
                departamentoDto.IdDepartamento = 0;
                Respuesta<bool> validar = _departamentoDomainService.ValidarDepartamentos(departamentoDto, departamentos);

                if (!validar.Ok)
                    return Respuesta.Fault<DepartamentoDto>(validar.Mensaje, validar.Codigo);

                var departamento = _mapper.Map<Departamento>(departamentoDto);

                DepartamentoValidator validator = new DepartamentoValidator();

                ValidationResult validationResult = validator.Validate(departamento);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<DepartamentoDto>(menssageValidation, Codigos.BadRequest);
                }

                var departamentoAEditar = _unitOfWork.Repository<Departamento>().Where(x => x.IdDepartamento == departamento.IdDepartamento).FirstOrDefault();

                if (departamentoAEditar != null)
                {
                    departamentoAEditar.Codigo = departamento.Codigo;
                    departamentoAEditar.Nombre = departamento.Nombre;
                    departamentoAEditar.UsuaModificacion = 1;
                    departamentoAEditar.FechaModificacion = DateTime.Now;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<DepartamentoDto>(departamentoAEditar), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch 
            {
                return Respuesta.Fault<DepartamentoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<string> EliminarDepartamentos(int Id)
        {
            try
            {
                var departamentoAEliminar = _unitOfWork.Repository<Departamento>().Where(x => x.IdDepartamento == Id).FirstOrDefault();

                if (departamentoAEliminar != null)
                    departamentoAEliminar.Estado = false;

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
