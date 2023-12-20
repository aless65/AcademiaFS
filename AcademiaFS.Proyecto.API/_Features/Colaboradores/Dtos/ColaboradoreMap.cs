using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos
{
    public class ColaboradoreMap
    {
        public int IdColaborador { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<SucursalesXcolaboradore> SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradore>();
    }
}
