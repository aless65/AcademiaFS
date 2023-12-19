using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.SucursalXColaboradores
{
    public class SucursalXColaboradorMap : IEntityTypeConfiguration<SucursalesXcolaboradore>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SucursalesXcolaboradore> builder)
        {
            builder.HasKey(e => e.IdSucursalXcolaborador).HasName("PK_SucursalesXColaboradores_IdSucursalXColaborador");

            builder.ToTable("SucursalesXColaboradores");

            builder.HasIndex(e => new { e.IdSucursal, e.IdColaborador }, "UC_SucursalesXColaboradores_IdSucursal_IdColaborador").IsUnique();

            builder.Property(e => e.IdSucursalXcolaborador).HasColumnName("IdSucursalXColaborador");
            builder.Property(e => e.DistanciaKm).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            builder.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.SucursalesXcolaboradores)
                .HasForeignKey(d => d.IdColaborador)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SucursalesXcolaboradores)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.SucursalesXcolaboradores)
            //    .HasForeignKey(d => d.UsuaCreacion)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_SucursalesXColaboradores_Usuarios_UsuaCreacion_IdUsuario");
        }
    }
}
