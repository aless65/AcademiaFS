using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Departamentos.Dto;
using AcademiaFS.Proyecto.API._Features.Municipios.Dto;
using AcademiaFS.Proyecto.API._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AutoMapper;

namespace AcademiaFS.Proyecto.API.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Colaboradore, ColaboradoreDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Municipio, MunicipioDto>().ReverseMap();
            CreateMap<Municipio, MunicipioListarDto>().ReverseMap();
            CreateMap<Sucursale, SucursaleDto>().ReverseMap();
            CreateMap<SucursalesXcolaboradore, SucursalesXcolaboradoreDto>().ReverseMap();
            CreateMap<Transportista, TransportistaDto>().ReverseMap();
            CreateMap<Viaje, ViajeDto>().ReverseMap();
            CreateMap<ViajesDetalle, ViajesDetalleListarDto>().ReverseMap();
            CreateMap<Viaje, ViajeListarDto>().ReverseMap();
            CreateMap<ViajesDetalle, ViajesDetalleDto>().ReverseMap();

        }
    }
}
