using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Usuarios
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
        }

        public Respuesta<Usuario?> Login(string username, string password)
        {
            var respuesta = _unitOfWork.Repository<Usuario>().Where(x => x.Nombre.Equals(username) && x.Contrasena.Equals(password)).FirstOrDefault();

            if (respuesta != null)
            {
                return Respuesta.Success(respuesta, "Sesión iniciada", "200");
            }
            else
            {
                return Respuesta.Fault("Usuario o contraseña incorrectos", "404", respuesta);
            }
        }
    }
}
 