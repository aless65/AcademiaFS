using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
//using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Usuarios
{
    public class UsuarioService
    {
        private readonly SistemaViajesDBContext _db;

        public UsuarioService(SistemaViajesDBContext db)
        {
            _db = db;
        }

        public Respuesta<UsuariosEntity?> Login(string username, string password)
        {
            var respuesta = _db.Usuarios.Where(x => x.Nombre.Equals(username) && x.Contrasena.Equals(password)).FirstOrDefault();

            if (respuesta != null)
            {
                return Respuesta.Success(respuesta, "Éxito", "200");
            }
            else
            {
                return Respuesta.Fault("Usuario o contraseña incorrectos", "404", respuesta);
            }
        }
    }
}
 