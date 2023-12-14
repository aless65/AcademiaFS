using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaborador;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.SucursalXColaborador;
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

        public DbSet<ColaboradoresEntity> Colaboradores { get; set; }
        public DbSet<tbSucursalesXColaboradores> SucursalesXColaboradores { get; set; }
        public DbSet<UsuariosEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradoresMap());
            modelBuilder.ApplyConfiguration(new tbSucursalesXColaboradoresMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
        }
    }
}
