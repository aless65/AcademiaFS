using AutoMapper;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace Academia.Proyecto.API.Infraestructure
{
    public class MapProfile : Profile
    {
        //CreateMap<SucursalDto, Sucursal>();
        public MapProfile() {
            CreateMap<Usuario, UsuarioAuditoriaDto>().ReverseMap();

            CreateMap<Viaje, ViajeDto>().ReverseMap();
        }
    }
}
