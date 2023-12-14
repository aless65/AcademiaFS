using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Sucursales
{
    public class SucursalMap : IEntityTypeConfiguration<_Features.Sucursales.Entities.Sucursal>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Sucursales.Entities.Sucursal> builder)
        {
            builder.HasKey(x => x.SucuId);
        }
    }
}
