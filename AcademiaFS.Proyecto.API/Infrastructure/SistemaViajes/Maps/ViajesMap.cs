﻿using System.IdentityModel;
using Microsoft.EntityFrameworkCore;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps
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

            builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.ViajeUsuaCreacionNavigations)
                .HasForeignKey(d => d.UsuaCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Viajes_Usuarios_UsuaCreacion_IdUsuario");

            builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.ViajeUsuaModificacionNavigations)
                .HasForeignKey(d => d.UsuaModificacion)
                .HasConstraintName("FK_Viajes_Usuarios_UsuaModificacion_IdUsuario");

        }
    }
}
