using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<_Features.Usuarios.Entities.Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Usuarios.Entities.Usuario> builder)
        {
            builder.ToTable("tbUsuarios");

            builder.Property(x => x.Id).HasColumnName("usua_Id");
            builder.Property(x => x.Nombre).HasColumnName("usua_Nombre").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Contrasena).HasColumnName("usua_Contrasena").IsRequired();
            builder.Property(x => x.Imagen).HasColumnName("usua_Imagen");
            builder.Property(x => x.Admin).HasColumnName("usua_EsAdmin");
            builder.Property(x => x.rolId).HasColumnName("role_Id");
            builder.Property(x => x.Estado).HasColumnName("usua_Estado");
            builder.Property(x => x.UsuaCreacion).HasColumnName("usua_UsuaCreacion");
            builder.Property(x => x.FechaCreacion).HasColumnName("usua_FechaCreacion").HasColumnType("datetime");
            builder.Property(x => x.UsuaModificacion).HasColumnName("usua_UsuaModificacion ");
            builder.Property(x => x.FechaModificacion).HasColumnName("usua_FechaModificacion ").HasColumnType("datetime");

            builder.HasKey(x => x.Id).HasName("PK_acce_tbUsuarios_usua_Id");
            builder.HasIndex(x => x.Nombre).IsUnique();
            builder.HasOne(d => d.role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.rolId)
                .HasConstraintName("FK_acce_tbUsuarios_tbRoles_role_Id");
        }
    }
}
