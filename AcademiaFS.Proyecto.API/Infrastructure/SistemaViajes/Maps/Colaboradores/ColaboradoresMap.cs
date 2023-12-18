using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps.Colaboradores
{
    public class ColaboradoresMap : IEntityTypeConfiguration<Colaboradore>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Colaboradore> builder)
        {
            builder.HasKey(e => e.IdColaborador).HasName("PK_Colaboradores_IdColaborador");

            builder.HasIndex(e => e.Identidad, "UC_Colaboradores_Identidad").IsUnique();

            builder.Property(e => e.Apellidos).HasMaxLength(300);
            builder.Property(e => e.Direccion).HasMaxLength(600);
            builder.Property(e => e.Estado)
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

            //builder.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colaboradores)
            //    .HasForeignKey(d => d.IdMunicipio)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.HasOne(d => d.UsuaCreacionNavigation).WithMany(p => p.ColaboradoreUsuaCreacionNavigations)
            //    .HasForeignKey(d => d.UsuaCreacion)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Colaboradores_Usuarios_UsuaCreacion_IdUsuario");

            //builder.HasOne(d => d.UsuaModificacionNavigation).WithMany(p => p.ColaboradoreUsuaModificacionNavigations)
            //    .HasForeignKey(d => d.UsuaModificacion)
            //    .HasConstraintName("FK_Colaboradores_Usuarios_Modificacion_IdUsuario");
        }
    }
}
