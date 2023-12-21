using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AutoMapper;

namespace AcademiaFS.Proyecto.API.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Transportista, TransportistaDto>().ReverseMap();
            CreateMap<Colaboradore, ColaboradoreDto>().ReverseMap();
            CreateMap<SucursalesXcolaboradore, SucursalesXcolaboradoreDto>().ReverseMap();
            CreateMap<Viaje, ViajeDto>().ReverseMap();
            CreateMap<ViajesDetalle, ViajesDetalleListarDto>().ReverseMap();
            CreateMap<Viaje, ViajeListarDto>().ReverseMap();
            CreateMap<ViajesDetalle, ViajesDetalleDto>().ReverseMap();

        }
    }
}
