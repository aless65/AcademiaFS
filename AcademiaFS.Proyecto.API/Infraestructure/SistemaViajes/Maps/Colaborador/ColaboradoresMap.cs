using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaborador
{
    public class ColaboradoresMap : IEntityTypeConfiguration<ColaboradoresEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ColaboradoresEntity> builder)
        {
            builder.HasKey(x => x.cola_Id);
            builder.HasIndex(x => x.cola_Identidad).IsUnique();
        }
    }
}
