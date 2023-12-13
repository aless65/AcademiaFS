using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaborador;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Usuario;
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

        public DbSet<tbColaboradores> Colaboradores { get; set; }
        public DbSet<tbUsuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new tbColaboradoresMap());
            modelBuilder.ApplyConfiguration(new tbUsuariosMap());
        }
    }
}
