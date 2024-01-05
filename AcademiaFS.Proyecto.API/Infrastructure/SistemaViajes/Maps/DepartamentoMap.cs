using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(e => e.IdDepartamento).HasName("PK_Departamentos_IdDepartamento");

            builder.HasIndex(e => e.Nombre, "UC_Departamentos_Nombre").IsUnique();

            builder.Property(e => e.Codigo).HasMaxLength(2);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(300);

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.DepartamentoUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departamentos_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.DepartamentoUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Departamentos_Usuarios_UsuaModificacion_IdUsuario");
        }
    }
}
