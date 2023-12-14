// See https://aka.ms/new-console-template for more information
using AcademiaFS.Proyecto.Consola._Login;

LoginService login = new LoginService();

Console.WriteLine("Bienvenido");

Console.Write("Nombre de usuario: ");   
string username = Console.ReadLine();

Console.Write("Contraseña: ");
string password = Console.ReadLine();

if(username != null && password != null)
{
    await login.IniciarSesion(username, password);
}