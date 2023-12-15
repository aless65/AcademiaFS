using AcademiaFS.Proyecto.Consola._Common;
using AcademiaFS.Proyecto.Consola._Common.Models;
using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models;
using AcademiaFS.Proyecto.Consola.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Colaboradores
{
    public class ColaboradorClient
    {
        public async Task<List<ColaboradorDto>> ObtenerColaboradores()
        {
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.GetAsync<List<ColaboradorDto>>("Colaborador/Listar");

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new List<ColaboradorDto>();
            }

            return respuesta.Item1;
        }

        public async Task<Respuesta> AgregarColaboradores(ColaboradorDto colaborador)
        {
            //Console.WriteLine(colaborador);
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.PostAsync<Respuesta>("Colaborador/Insertar", colaborador);

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new Respuesta();
            }

            return respuesta.Item1;
        }
    }
}
