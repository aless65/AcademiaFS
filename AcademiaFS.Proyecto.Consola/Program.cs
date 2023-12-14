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
        usuario = JsonSerializer.Deserialize<UsuarioDto>(response.data.ToString());
}