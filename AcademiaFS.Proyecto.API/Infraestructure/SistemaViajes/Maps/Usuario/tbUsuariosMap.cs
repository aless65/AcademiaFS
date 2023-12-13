using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps.Usuario
{
    public class tbUsuariosMap : IEntityTypeConfiguration<tbUsuarios>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<tbUsuarios> builder)
        {
            builder.HasKey(x => x.usua_Id);
        }
    }
}
