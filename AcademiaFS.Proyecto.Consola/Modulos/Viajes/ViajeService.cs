using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Viajes
{
    public class ViajeService
    {
        private readonly ViajeClient _client;
        public ViajeService()
        {
            _client = new ViajeClient();
        }
        public async Task<bool> ListarViajes()
        {
            var respuesta = await _client.ObtenerViajes();

            Console.Clear();

            while (true)
            {
                if (respuesta.Count > 0)
                {
                    Console.WriteLine("Id - Fecha y hora - Total Km - Sucursal - Transportista");
                    foreach (var item in respuesta)
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{item.TranId} - {item.ViajFechaYHora} - {item.ViajTotalKm} - {item.TranId}\n");
                        Console.WriteLine("Sucursales asignadas:");
                        if (item.ViajeDetalles != null)
                            foreach (var item2 in item.ViajeDetalles)
                            {
                                Console.WriteLine($"Colaborador: {item2.ColId} - Distancia en km: {item2.VideDistancia}");
                            }
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Actualmente no hay viajes");
                }

                Console.WriteLine("");
                Console.WriteLine("Toque cualquier tecla para regresar al menú");

                Console.ReadKey();
                Console.Clear();
                break;
            }

            return true;
        }

        public async Task<bool> ReporteViajes()
        {
            Console.Clear();

            Console.Write("Fecha inicio: ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha fin: ");
            DateTime fechaFinal = DateTime.Parse(Console.ReadLine());

            var respuesta = await _client.ReporteViajes(fechaInicio, fechaFinal);

            while (true)
            {
                if (respuesta != null)
                {
                    Console.WriteLine("Total a pagar: " + respuesta.totalAPagar);
                    Console.WriteLine("Data sin arreglar XD\n" + respuesta.reporte);
                }
                else
                {
                    Console.WriteLine("No hay información en este rango de fechas");
                }

                Console.WriteLine("");
                Console.WriteLine("Toque cualquier tecla para regresar al menú");

                Console.ReadKey();
                Console.Clear();
                break;
            }

            return true;
        }
    }
}
