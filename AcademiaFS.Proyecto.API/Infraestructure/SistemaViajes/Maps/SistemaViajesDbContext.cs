using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaboradores;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Sucursales;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.SucursalXColaboradores;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Transportistas;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Usuarios;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Viajes;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.ViajesDetalles;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps
{
    public class SistemaViajesDBContext : DbContext
    {
        public SistemaViajesDBContext()
        {
        }

        public SistemaViajesDBContext(DbContextOptions<SistemaViajesDBContext> options) : base(options)
        {

        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<SucursalXColaborador> SucursalesXColaboradores { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajeDetalles> ViajeDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradoresMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new SucursalXColaboradorMap());
            modelBuilder.ApplyConfiguration(new TransportistaMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new ViajesMap());
            modelBuilder.ApplyConfiguration(new ViajeDetallesMap());
        }
    }
}
