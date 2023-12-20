using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.Repositories;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Farsiman.Infraestructure.Core.Entity.Standard.Extensions;
using System.IdentityModel;

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

var connectionString = builder.Configuration.GetConnectionString("SistemaViaje");
builder.Services.AddDbContext<SistemaViajesDBContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();

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
//AgregarDatosDeInicio(app);

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



