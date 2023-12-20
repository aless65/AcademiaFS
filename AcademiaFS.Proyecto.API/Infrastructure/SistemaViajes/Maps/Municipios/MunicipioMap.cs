using AcademiaFS.Proyecto.API._Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Municipios
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
        }
    }
}
