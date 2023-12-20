using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Sucursales
{
    public class SucursalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
        }

        public Respuesta<List<Sucursale>> ListarSucursales()
        {
            var listado = _unitOfWork.Repository<Sucursale>().AsQueryable().ToList();

            return Respuesta.Success<List<Sucursale>>(listado, "Bien", "200");
        }
    }
}
