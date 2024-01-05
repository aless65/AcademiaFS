using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.IdRol).HasName("PK_Roles_IdRol");

            builder.Property(e => e.Estado).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
            .IsUnicode(false);

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.RolUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Usuarios_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.RolUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Roles_Usuarios_IdUsuarioModificacion_IdUsuario");
        }
    }
}
