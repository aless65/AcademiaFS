using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.HasKey(e => e.IdMunicipio).HasName("PK_Municipios_IdMunicipio");

            builder.HasIndex(e => e.Nombre, "UC_Municipios_Nombre").IsUnique();

            builder.Property(e => e.Codigo).HasMaxLength(4);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(300);

            builder.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.MunicipioUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipios_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.MunicipioUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Municipios_Usuarios_UsuaModificacion_IdUsuario");
        }
    }
}
