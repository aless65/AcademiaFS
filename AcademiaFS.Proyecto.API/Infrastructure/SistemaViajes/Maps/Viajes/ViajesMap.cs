using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using System.IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Viajes
{
    public class ViajesMap : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Viaje> builder)
        {
            builder.HasKey(e => e.IdViaje).HasName("PK_Viajes_IdViaje");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.FechaYhora)
                .HasColumnType("datetime")
                .HasColumnName("FechaYHora");
            builder.Property(e => e.TarifaActual).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TotalKm).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdTransportistaNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdTransportista)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
