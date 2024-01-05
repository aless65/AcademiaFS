using System.IdentityModel;
using Microsoft.EntityFrameworkCore;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
{
    public class ViajeDetallesMap : IEntityTypeConfiguration<ViajesDetalle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ViajesDetalle> builder)
        {
            builder.HasKey(e => e.IdViajeDetalle).HasName("PK_ViajesDetalles_IdViajeDetalle");

            builder.Property(e => e.DistanciaActual).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.ViajesDetalles)
               .HasForeignKey(d => d.IdColaborador)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdViajeNavigation).WithMany(p => p.ViajesDetalles)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.ViajesDetalleUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViajesDetalles_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.ViajesDetalleUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_ViajesDetalles_Usuarios_UsuaModificacion_IdUsuario");
        }
    }
}
