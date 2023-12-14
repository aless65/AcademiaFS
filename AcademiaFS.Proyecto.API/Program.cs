using Academia.Proyecto.API.Infraestructure;
using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
//using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ContextBellacoXD>(o => o.UseSqlServer(
//        builder.Configuration.GetConnectionStringFromENV("BELLACA")
//    ));

builder.Services.AddDbContext<SistemaViajesDBContext>(o => o.UseInMemoryDatabase("SistemaViajes"));

builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddFsAuthService((options) =>
//{
//    options.Username = builder.Configuration.GetFromENV("FsIdentity:Username");
//    options.Password = builder.Configuration.GetFromENV("FsIdentity:Password");
//});

builder.Services.AddTransient<ColaboradorService>();
builder.Services.AddTransient<UsuarioService>();

var app = builder.Build();

//AgregarDataColaboradores(app);
AgregarUsuarioParaLogin(app);

//app.UseFsWebApiExceptionHandler(builder.Configuration["seq:url"], builder.Configuration["seq:key"]);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
//app.UseFsAuthService();
app.MapControllers();

app.Run();

static void AgregarUsuarioParaLogin(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetService<SistemaViajesDBContext>();

    var usuario = new UsuariosEntity
    {
        Id = 1,
        Nombre = "admin",
        Contrasena = "123",
        Admin = true,
        Estado = true,
        UsuaCreacion = 1,
        FechaCreacion = DateTime.Now,
    };

    db.Usuarios.Add(usuario);
    db.SaveChanges();
}

//static void AgregarDataColaboradores(WebApplication app)
//{
//    var scope = app.Services.CreateScope();
//    var db = scope.ServiceProvider.GetService<SistemaViajesDBContext>();

//    var colaborador1 = new tbColaboradores
//    {
//        cola_Id = 1,
//        cola_Nombres = "Andrea",
//        cola_Apellidos = "Hernández",
//        cola_Identidad = "0501200506728",
//        cola_Direccion = "Calle de la chinaaaa",
//        muni_Id = 1,
//        cola_FechaNacimiento = new DateTime(2005,02,28),
//        cola_Sexo = "F",
//        cola_Estado = true,
//        cola_UsuaCreacion = 1,
//        cola_FechaCreacion = DateTime.Now,
//    };

//    var colaborador2 = new tbColaboradores
//    {
//        cola_Id = 2,
//        cola_Nombres = "Marlon",
//        cola_Apellidos = "Montecarlo",
//        cola_Identidad = "0501200006768",
//        cola_Direccion = "Calle de la chinaaa a",
//        muni_Id = 1,
//        cola_FechaNacimiento = new DateTime(2000, 05, 01),
//        cola_Sexo = "F",
//        cola_Estado = true,
//        cola_UsuaCreacion = 1,
//        cola_FechaCreacion = DateTime.Now,
//    };

//    db.Colaboradores.Add(colaborador1);
//    db.Colaboradores.Add(colaborador2);

//    db.SaveChanges();
//}