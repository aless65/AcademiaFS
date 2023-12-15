using AcademiaFS.Proyecto.Consola._Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola._Login
{
    public class LoginService
    {
        private readonly LoginClient _loginClient;
        public LoginService()
        {
            _loginClient = new LoginClient();
        }

        public async Task<Respuesta> IniciarSesion(string username, string password)
        {
            var respuesta = await _loginClient.IniciarSesion(username, password);

            Console.WriteLine(respuesta.mensaje);

            return respuesta;
        }
    }
}
