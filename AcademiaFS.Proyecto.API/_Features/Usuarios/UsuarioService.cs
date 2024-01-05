using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
        }

        //public Respuesta<UsuarioDto> Login(string username, string password)
        //{
        //    var respuesta = (from usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
        //                     where usuario.Nombre == username && usuario.Contrasena == password && usuario.Estado == true
        //                     select new UsuarioDto
        //                     {
        //                         Nombre = usuario.Nombre,
        //                         EsAdmin = usuario.EsAdmin,
        //                         IdUsuario = usuario.IdUsuario,
        //                         IdRol = usuario.IdRol,
        //                     }).FirstOrDefault();

        //    if (respuesta != null)
        //    {
        //        return Respuesta.Success(respuesta, Mensajes.LOGIN_EXITOSO, Codigos.Success);
        //    }
        //    else
        //    {
        //        return Respuesta.Fault<UsuarioDto>(Mensajes.LOGIN_FALLIDO, Codigos.BadRequest);
        //    }
        //}
    }
}
 