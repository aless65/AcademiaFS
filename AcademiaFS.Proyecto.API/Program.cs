using AcademiaFS.Proyecto.API._Features.Colaboradores;
using AcademiaFS.Proyecto.API._Features.Sucursales;
using AcademiaFS.Proyecto.API._Features.Transportistas;
using AcademiaFS.Proyecto.API._Features.Usuarios;
using AcademiaFS.Proyecto.API._Features.Viajes;
using AcademiaFS.Proyecto.API.Infrastructure;

//using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using AcademiaFS.Proyecto.API.Domain;
using Farsiman.Extensions.Configuration;
using AcademiaFS.Proyecto.API._Features.Departamentos;
using AcademiaFS.Proyecto.API._Features.Municipios;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes;
using AcademiaFS.Proyecto.API._Features.Auth;
using Academia.Proyecto.API._Common;

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

//builder.Services.AddSwaggerForFsIdentityServer(opt =>
//{
//    opt.Title = "Transporte";
//    opt.Description = "Wow";
//    opt.Version = "v1";
//});

//builder.Services.AddDbContext<ContextBellacoXD>(o => o.UseSqlServer(
//        builder.Configuration.GetConnectionStringFromENV("BELLACA")
//    ));

var connectionString = builder.Configuration.GetConnectionString("SistemaViaje");
builder.Services.AddDbContext<SistemaViajesDBContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();

builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddFsAuthService(configureOptions =>
//{
//    configureOptions.Username = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Username");
//    configureOptions.Password = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Password");
//});


builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddTransient<ColaboradorDomainService>();
builder.Services.AddTransient<IColaboradorService, ColaboradorService>();

builder.Services.AddTransient<CommonService>();

builder.Services.AddTransient<DepartamentoDomainService>();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();

builder.Services.AddTransient<MunicipioDomainService>();
builder.Services.AddTransient<IMunicipioService, MunicipioService>();

builder.Services.AddTransient<SucursalDomainService>();
builder.Services.AddTransient<ISucursalService, SucursalService>();

builder.Services.AddTransient<ITransportistaService, TransportistaService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IViajeService, ViajeService>();

builder.Services.AddTransient<DomainService>();

var app = builder.Build();

//AgregarDataColaboradores(app);
//AgregarDatosDeInicio(app);

//app.UseFsWebApiExceptionHandler(builder.Configuration["seq:url"], builder.Configuration["seq:key"]);

if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerWithFsIdentityServer();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
//app.UseFsAuthService();
app.MapControllers();

app.Run();



