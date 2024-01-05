using AcademiaFS.Proyecto.API._Features.Usuarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Auth
{
    public interface IAuthService
    {
        Respuesta<UsuarioListarDto> Login(string username, string password);
    }
}
