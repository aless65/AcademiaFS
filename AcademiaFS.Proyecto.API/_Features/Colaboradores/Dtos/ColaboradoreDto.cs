using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos
{
    public class ColaboradoreDto
    {
        public int IdColaborador { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public virtual ICollection<SucursalesXcolaboradoreDto>? SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradoreDto>();
    }
}
