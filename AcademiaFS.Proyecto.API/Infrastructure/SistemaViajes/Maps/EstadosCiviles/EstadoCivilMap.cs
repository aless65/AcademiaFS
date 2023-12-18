using AcademiaFS.Proyecto.API._Features.EstadosCiviles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.EstadosCiviles
{
    public class EstadoCivilMap : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.HasKey(e => e.IdEstadoCivil).HasName("PK_EstadosCiviles_IdEstadoCivil");

            builder.HasIndex(e => e.Nombre, "UC_EstadosCiviles_Nombre").IsUnique();

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
