﻿using AcademiaFS.Proyecto.Consola.Modulos.Transportistas._Models;
using AcademiaFS.Proyecto.Consola.Modulos.Viajes._Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Transportistas
{
    public class TransportistaService
    {
        private readonly TransportistaClient _client;
        public TransportistaService()
        {
            _client = new TransportistaClient();
        }

        public async Task<bool> ListarTransportistas()
        {
            var respuesta = await _client.ObtenerTransportistas();

            Console.Clear();

            while (true)
            {
                if (respuesta.Count > 0)
                {
                    Console.WriteLine("Id - Nombres - Apellidos - Identidad - Tarifa Km");
                    foreach (var item in respuesta)
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{item.TranId} - {item.TranNombres} - {item.TranApellidos} - {item.TranTarifaKm}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Actualmente no hay transportistas");
                }

                Console.WriteLine("");
                Console.WriteLine("Toque cualquier tecla para regresar al menú");

                Console.ReadKey();
                Console.Clear();
                break;
            }

            return true;
        }

        public async Task<bool> InsertarTransportista(int usuaId)
        {
            Console.Clear();

            TransportistaDto trans = new();

            Console.Write("Nombres: ");
            trans.TranNombres = Console.ReadLine();
            Console.Write("Apellidos: ");
            trans.TranApellidos = Console.ReadLine();
            Console.Write("Identidad: ");
            trans.TranIdentidad = Console.ReadLine();
            Console.Write("Tarifa por kilómetro: ");
            trans.TranTarifaKm = decimal.Parse(Console.ReadLine());




            trans.TranUsuaCreacion = usuaId;

            var respuesta = await _client.AgregarTransportistas(trans);

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
