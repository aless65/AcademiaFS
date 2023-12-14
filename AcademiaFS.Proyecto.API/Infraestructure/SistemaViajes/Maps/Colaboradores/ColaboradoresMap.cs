using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Colaboradores
{
    public class ColaboradoresMap : IEntityTypeConfiguration<_Features.Colaboradores.Entities.Colaborador>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Colaboradores.Entities.Colaborador> builder)
        {
            builder.HasKey(x => x.ColId);
            builder.HasIndex(x => x.ColIdentidad).IsUnique();
        }
    }
}
