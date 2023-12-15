using AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Colaboradores
{
    public class ColaboradorService
    {
        private readonly ColaboradorClient _client;
        public ColaboradorService()
        {
            _client = new ColaboradorClient();
        }

        public async Task<bool> ListarColaboradores()
        {
            var respuesta = await _client.ObtenerColaboradores();

            Console.Clear();

            while (true)
            {
                if(respuesta.Count > 0)
                {
                    Console.WriteLine("Id - Nombres - Apellidos - Identidad");
                    foreach (var item in respuesta)
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{item.ColId} - {item.ColNombres} - {item.ColApellidos} - {item.ColIdentidad}\n");
                        Console.WriteLine("Sucursales asignadas:");
                        if(item.sucursalesXColaboradores != null)
                            foreach (var item2 in item.sucursalesXColaboradores)
                            {
                                Console.WriteLine($"Sucursal: {item2.SucuId} - Distancia en km: {item2.SucoDistanciaKm}");
                            }
                        Console.WriteLine("");
                    }
                } else
                {
                    Console.WriteLine("Actualmente no hay colaboradores");
                } 

                Console.WriteLine("");
                Console.WriteLine("Toque cualquier tecla para regresar al menú");

                Console.ReadKey();
                Console.Clear();
                break;
            }

            return true;
        }

        public async Task<bool> InsertarColaboradores(int usuaId)
        {
            Console.Clear();

            ColaboradorDto colaborador = new();

            Console.Write("Nombres: ");
            colaborador.ColNombres = Console.ReadLine();
            Console.Write("Apellidos: ");
            colaborador.ColApellidos = Console.ReadLine();
            Console.Write("Identidad: ");
            colaborador.ColIdentidad = Console.ReadLine();
            Console.Write("Sexo: ");
            colaborador.ColSexo = Console.ReadLine();
            Console.Write("Direccion: ");
            colaborador.ColDireccion = Console.ReadLine();

            Console.WriteLine("\nAsignar sucursales");

            colaborador.sucursalesXColaboradores = new List<SucursalXColaboradorDto>();

            bool insertarSucu = true;
            while (insertarSucu)
            {
                SucursalXColaboradorDto sucursalXColaboradorDto = new();
                Console.Write("Sucursal Id: ");
                sucursalXColaboradorDto.SucuId = int.Parse(Console.ReadLine());
                Console.Write("Distancia en Km: ");
                sucursalXColaboradorDto.SucoDistanciaKm = decimal.Parse(Console.ReadLine());

                colaborador.sucursalesXColaboradores.Add(sucursalXColaboradorDto);

                Console.WriteLine("\n¿Desea seguir asignando? S/N");
                string seguir = Console.ReadLine();

                switch (seguir.ToUpper())
                {
                    case "S":
                        Console.WriteLine("");
                        break;
                    case "N":
                        insertarSucu = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una tecla válida");
                        break;
                }
            }

            colaborador.ColUsuaCreacion = usuaId;

            var respuesta = await _client.AgregarColaboradores(colaborador);

            Console.WriteLine("");
            Console.WriteLine(respuesta.mensaje);
            Console.WriteLine("");

            Console.WriteLine("Toque cualquier tecla para regresar al menú");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
    }
}
