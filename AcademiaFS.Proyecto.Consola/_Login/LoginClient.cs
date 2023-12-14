using AcademiaFS.Proyecto.Consola._Common;
using AcademiaFS.Proyecto.Consola._Common.Models;
using AcademiaFS.Proyecto.Consola.Utility;
//using Farsiman.Application.Core.Standard.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola._Login
{
    public class LoginClient
    {
        public async Task<Respuesta> IniciarSesion(string username, string password)
        {
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.PostAsync<Respuesta>($"Usuario/Login/{username}/{password}");

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new Respuesta();
            }

            return respuesta.Item1;
        }
    }
}
