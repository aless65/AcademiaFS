using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AutoMapper;

namespace AcademiaFS.Proyecto.API.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Transportista, TransportistaDto>().ReverseMap();
            CreateMap<Colaboradore, ColaboradoreDto>().ReverseMap();
            CreateMap<Colaboradore, ColaboradoreListarDto>().ReverseMap();
            CreateMap<SucursalesXcolaboradore, SucursalesXcolaboradoreDto>().ReverseMap();
            CreateMap<SucursalesXcolaboradore, SucursalesXcolaboradoreListarDto>().ReverseMap();
        }
    }
}
