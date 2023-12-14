using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.SucursalXColaborador
{
    public class tbSucursalesXColaboradoresMap : IEntityTypeConfiguration<_Features.Colaboradores.Entities.SucursalXColaborador>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<_Features.Colaboradores.Entities.SucursalXColaborador> builder)
        {
            builder.HasKey(x => x.suco_Id);
        }
    }
}
