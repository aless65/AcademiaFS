using AcademiaFS.Proyecto.Consola._Common;
using AcademiaFS.Proyecto.Consola._Common.Models;
using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models;
using AcademiaFS.Proyecto.Consola.Modulos.Transportistas._Models;
using AcademiaFS.Proyecto.Consola.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Transportistas
{
    public class TransportistaClient
    {
        public async Task<List<TransportistaDto>> ObtenerTransportistas()
        {
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.GetAsync<List<TransportistaDto>>("Transportista/Listar");

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new List<TransportistaDto>();
            }

            return respuesta.Item1;
        }

        public async Task<Respuesta> AgregarTransportistas(TransportistaDto transportista)
        {
            //Console.WriteLine(colaborador);
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.PostAsync<Respuesta>("Transportista/Insertar", transportista);

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new Respuesta();
            }

            return respuesta.Item1;
        }
    }
}
