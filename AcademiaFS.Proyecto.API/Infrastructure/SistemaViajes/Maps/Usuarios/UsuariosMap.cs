using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<_Features.Usuarios.Entities.Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Usuarios.Entities.Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario).HasName("PK_Usuarios_IdUsuarios");

            builder.HasIndex(e => e.Nombre, "UC_Usuarios_Nombre").IsUnique();

            builder.Property(e => e.Nombre).HasMaxLength(50);
            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_acce_tbUsuarios_tbRoles_role_Id");

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.InverseUsuaCreacionNavigation)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.InverseUsuaModificacionNavigation)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Usuarios_Usuarios_UsuaModificacion_IdUsuario");
        }
    }
}
