using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.ViajesDetalles
{
    public class ViajeDetallesMap : IEntityTypeConfiguration<ViajeDetalles>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ViajeDetalles> builder)
        {
            builder.HasKey(x => x.VideId);
        }
    }
}
