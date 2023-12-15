using AcademiaFS.Proyecto.Consola._Common;
using AcademiaFS.Proyecto.Consola._Common.Models;
using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models;
using AcademiaFS.Proyecto.Consola.Modulos.Viajes._Models;
using AcademiaFS.Proyecto.Consola.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Viajes
{
    public class ViajeClient
    {
        public async Task<List<ViajeDto>> ObtenerViajes()
        {
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.GetAsync<List<ViajeDto>>("Viaje/Listar");

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new List<ViajeDto>();
            }

            return respuesta.Item1;
        }

        public async Task<Respuesta> AgregarViajes(ViajeDto viaje)
        {
            //Console.WriteLine(colaborador);
            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.PostAsync<Respuesta>("Viaje/Insertar", viaje);

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new Respuesta();
            }

            return respuesta.Item1;
        }

        public async Task<ViajeReporteDto> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
        {
            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinalStr = fechaFinal.ToString("yyyy-MM-dd");

            HttpClientFs client = new HttpClientFs(RutaApi.Maestros.GetApiRoute());
            var respuesta = await client.GetAsync<ViajeReporteDto>($"Viaje/Reporte/{fechaInicioStr}/{fechaFinalStr}");

            if (!string.IsNullOrEmpty(respuesta.Item2))
            {
                Console.WriteLine("Ha ocurrido un error: " + respuesta.Item2);
                return new ViajeReporteDto();
            }

            return respuesta.Item1;
        }
    }
}
