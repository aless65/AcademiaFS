using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.SucursalXColaborador
{
    public class tbSucursalesXColaboradoresMap : IEntityTypeConfiguration<tbSucursalesXColaboradores>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<tbSucursalesXColaboradores> builder)
        {
            builder.HasKey(x => x.suco_Id);
        }
    }
}
