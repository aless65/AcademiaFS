using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaborador
{
    public class tbColaboradoresMap : IEntityTypeConfiguration<tbColaboradores>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<tbColaboradores> builder)
        {
            //builder.ToTable("tbColaboradores");
            builder.HasKey(x => x.cola_Id);
            //builder.Property(x => x.cola_Nombres).HasC
        }
    }
}
