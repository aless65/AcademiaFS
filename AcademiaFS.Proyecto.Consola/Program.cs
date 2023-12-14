// See https://aka.ms/new-console-template for more information
using AcademiaFS.Proyecto.Consola._Common.Models;
using AcademiaFS.Proyecto.Consola._Login;
using System.Text.Json;
using System.Text.Json.Nodes;

LoginService login = new LoginService();

Console.WriteLine("Bienvenido");

Console.Write("Nombre de usuario: ");   
string username = Console.ReadLine();

Console.Write("Contraseña: ");
string password = Console.ReadLine();

UsuarioDto usuario;

if(username != null && password != null)
{
    var response = await login.IniciarSesion(username, password);
    if(response.data != null)
    {
        usuario = JsonSerializer.Deserialize<UsuarioDto>(response.data.ToString());

        Console.Clear();

        while (true)
        {
            Console.WriteLine("Menú principal\n");
            Console.WriteLine("--- Colaboradores ---");
            Console.WriteLine("1. Listado de colaboradores");
            Console.WriteLine("2. Ingresar colaborador\n");
            Console.WriteLine("--- Transportistas ---");
            Console.WriteLine("3. Listado de transportistas");
            Console.WriteLine("4. Ingresar transportista\n");
            Console.WriteLine("--- Viajes ---");
            Console.WriteLine("5. Listado de viajes");
            Console.WriteLine("6. Ingresar viaje");
            Console.WriteLine("7. Reporte\n");
            Console.WriteLine("8. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    return;
            }
        }
    }
        
}