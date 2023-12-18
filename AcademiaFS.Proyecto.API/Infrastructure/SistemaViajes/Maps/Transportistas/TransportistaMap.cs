using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Transportistas
{
    public class TransportistaMap : IEntityTypeConfiguration<Transportista>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transportista> builder)
        {
            builder.HasKey(e => e.IdTransportista).HasName("PK_Transportistas_IdTransportista");

            builder.HasIndex(e => e.Identidad, "UC_Transportistas_Identidad").IsUnique();

            builder.Property(e => e.Apellidos).HasMaxLength(300);
            builder .Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.FechaNacimiento).HasColumnType("date");
            builder.Property(e => e.Identidad)
                .HasMaxLength(13)
                .IsUnicode(false);
            builder.Property(e => e.Nombres).HasMaxLength(300);
            builder.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            builder.Property(e => e.TarifaKm).HasColumnType("decimal(18, 2)");

            //builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.TransportistaUsuaCreacionNavigations)
            //    .HasForeignKey(d => d.UsuaCreacion)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Transportistas_Usuarios_UsuaCreacion_IdUsuario");

            //builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.TransportistaUsuaModificacionNavigations)
            //    .HasForeignKey(d => d.UsuaModificacion)
            //    .HasConstraintName("FK_Transportistas_Usuarios_Modificacion_IdUsuario");
        }
    }
}
