using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(UnitOfWorkBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
        }

        public Respuesta<UsuarioListarDto> Login(string username, string password)
        {
            var respuesta = (from usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                             join rol in _unitOfWork.Repository<Rol>().AsQueryable()
                             on usuario.IdRol equals rol.IdRol into rolleft
                             from subrol in rolleft.DefaultIfEmpty()
                             where usuario.Nombre == username && usuario.Contrasena == password && usuario.Estado == true
                             select new UsuarioListarDto
                             {
                                 Nombre = usuario.Nombre,
                                 EsAdmin = usuario.EsAdmin,
                                 IdUsuario = usuario.IdUsuario,
                                 IdRol = usuario.IdRol,
                                 NombreRol = subrol.Nombre,
                             }).FirstOrDefault();

            if (respuesta != null)
            {
                return Respuesta.Success(respuesta, Mensajes.LOGIN_EXITOSO, Codigos.Success);
            }
            else
            {
                return Respuesta.Fault<UsuarioListarDto>(Mensajes.LOGIN_FALLIDO, Codigos.BadRequest);
            }
        }
    }
}
