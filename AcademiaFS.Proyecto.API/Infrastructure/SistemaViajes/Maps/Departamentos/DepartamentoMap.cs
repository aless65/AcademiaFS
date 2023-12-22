using AcademiaFS.Proyecto.API._Features.Departamentos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Departamentos
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
        }
    }
}
