using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes
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
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sucursale> Sucursales { get; set; }
        public DbSet<SucursalesXcolaboradore> SucursalesXColaboradores { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajesDetalle> ViajesDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradoresMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new SucursalXColaboradorMap());
            modelBuilder.ApplyConfiguration(new TransportistaMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new ViajesMap());
            modelBuilder.ApplyConfiguration(new ViajeDetallesMap());
        }
    }
}
