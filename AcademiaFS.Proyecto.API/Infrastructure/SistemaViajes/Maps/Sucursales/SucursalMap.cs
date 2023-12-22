using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using System.IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Sucursales
{
    public class SucursalMap : IEntityTypeConfiguration<_Features.Sucursales.Entities.Sucursale>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Sucursales.Entities.Sucursale> builder)
        {
            builder.HasKey(e => e.IdSucursal).HasName("PK_Sucursales_IdSucursal");

            builder.HasIndex(e => e.Nombre, "UC_Sucursales_Nombre").IsUnique();

            builder.Property(e => e.Direccion).HasMaxLength(600);
            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(300);

            builder.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Sucursales)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.SucursaleUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursales_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.SucursaleUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Sucursales_Usuarios_Modificacion_IdUsuario");
        }
    }
}
