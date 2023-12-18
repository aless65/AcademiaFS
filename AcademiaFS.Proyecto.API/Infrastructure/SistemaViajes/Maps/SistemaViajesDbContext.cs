using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.EstadosCiviles.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Colaboradores;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.EstadosCiviles;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Sucursales;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.SucursalXColaboradores;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Transportistas;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Usuarios;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Viajes;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.ViajesDetalles;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
{
    public class SistemaViajesDBContext : DbContext
    {
        public SistemaViajesDBContext()
        {
        }

        public SistemaViajesDBContext(DbContextOptions<SistemaViajesDBContext> options) : base(options)
        {

        }

        public DbSet<Colaboradore> Colaboradores { get; set; }
        public DbSet<EstadoCivil> EstadosCiviles { get; set; }
        public DbSet<Sucursale> Sucursales { get; set; }
        public DbSet<SucursalesXcolaboradore> SucursalesXColaboradores { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajesDetalle> ViajeDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradoresMap());
            modelBuilder.ApplyConfiguration(new EstadoCivilMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new SucursalXColaboradorMap());
            modelBuilder.ApplyConfiguration(new TransportistaMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new ViajesMap());
            modelBuilder.ApplyConfiguration(new ViajeDetallesMap());
        }
    }
}
