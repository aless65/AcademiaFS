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
            //CreateMap<Usuario, UsuarioAuditoriaDto>().ReverseMap();

            //CreateMap<Viaje, ViajeDto>().ReverseMap();
        }
    }
}
