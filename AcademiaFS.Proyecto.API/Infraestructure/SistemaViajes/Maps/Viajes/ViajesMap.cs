using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Viajes
{
    public class ViajesMap : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Viaje> builder)
        {
            builder.HasKey(x => x.ViajId);
        }
    }
}
