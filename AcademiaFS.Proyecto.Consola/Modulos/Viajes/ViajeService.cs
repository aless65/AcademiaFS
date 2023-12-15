using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores;
using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models;
using AcademiaFS.Proyecto.Consola.Modulos.Viajes._Models;
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
                        Console.WriteLine("Detalles:");
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

        public async Task<bool> InsertarViajes(int usuaId, bool esAdmin)
        {
            Console.Clear();

            ViajeDto viaje = new();

            Console.Write("Fecha y hora: ");
            viaje.ViajFechaYHora = DateTime.Parse(Console.ReadLine());
            Console.Write("Transportista Id: ");
            viaje.TranId = int.Parse(Console.ReadLine());
            Console.Write("Tarifa actual: ");
            viaje.ViajTarifaActual = decimal.Parse(Console.ReadLine());
            Console.Write("Sucursal: ");
            viaje.SucuId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAsignar detalles");

            viaje.ViajeDetalles = new List<ViajeDetallesDto>();

            bool insertarDetalles = true;
            while (insertarDetalles)
            {
                ViajeDetallesDto viajeDetallesDto = new();
                Console.Write("Colaborador: ");
                viajeDetallesDto.ColId = int.Parse(Console.ReadLine());
                Console.Write("Distancia: ");
                viajeDetallesDto.VideDistancia = decimal.Parse(Console.ReadLine());

                viaje.ViajeDetalles.Add(viajeDetallesDto);

                Console.WriteLine("\n¿Desea seguir asignando? S/N");
                string seguir = Console.ReadLine();

                switch (seguir.ToUpper())
                {
                    case "S":
                        Console.WriteLine("");
                        break;
                    case "N":
                        insertarDetalles = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una tecla válida");
                        break;
                }
            }

            viaje.ViajUsuaCreacion = usuaId;
            viaje.admin = esAdmin;

            var respuesta = await _client.AgregarViajes(viaje);

            Console.WriteLine("");
            Console.WriteLine(respuesta.mensaje);
            Console.WriteLine("");

            Console.WriteLine("Toque cualquier tecla para regresar al menú");
            Console.ReadKey();
            Console.Clear();

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
