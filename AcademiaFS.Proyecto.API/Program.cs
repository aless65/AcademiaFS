using Academia.Proyecto.API.Infraestructure;
using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes;
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
builder.Services.AddTransient<SucursalService>();
builder.Services.AddTransient<TransportistaService>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<ViajeService>();

var app = builder.Build();

//AgregarDataColaboradores(app);
AgregarDatosDeInicio(app);

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

static void AgregarDatosDeInicio(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetService<SistemaViajesDBContext>();

    var usuario = new Usuario
    {
        Id = 1,
        Nombre = "admin",
        Contrasena = "123",
        Admin = true,
        Estado = true,
        UsuaCreacion = 1,
        FechaCreacion = DateTime.Now,
    };

    var sucursales = new List<Sucursal>
    {
        new Sucursal { 
            //SucuId = 1,
            SucuNombre = "Sucursal 1",
            SucuDireccion = "Direccion xd",
            SucuUsuaCreacion = 1,
            SucuFechaCreacion = DateTime.Now 
        },

        new Sucursal {
            //SucuId = 2,
            SucuNombre = "Sucursal 2",
            SucuDireccion = "Direccion xd",
            SucuUsuaCreacion = 1,
            SucuFechaCreacion = DateTime.Now
        }
    };

    var transportistas = new List<Transportista>
    {
        new Transportista {
            //TranId = 1,
            TranNombres = "Juan Hernan",
            TranApellidos = "De la CRUX",
            TranIdentidad = "03020156546",
            TranTarifaKm = 20,
        },

        new Transportista {
            //TranId = 2,
            TranNombres = "Marina",
            TranApellidos = "Saavedra",
            TranIdentidad = "03020156543",
            TranTarifaKm = 10,
        }
    };

    db.Usuarios.Add(usuario);
    db.Sucursales.AddRange(sucursales);
    db.Transportistas.AddRange(transportistas);
    db.SaveChanges();
}

