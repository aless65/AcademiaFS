using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Transportistas
{
    public class TransportistaMap : IEntityTypeConfiguration<Transportista>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transportista> builder)
        {
            builder.HasKey(x => x.TranId);
        }
    }
}
