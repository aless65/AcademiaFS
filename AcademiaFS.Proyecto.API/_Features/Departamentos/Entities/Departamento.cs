using AcademiaFS.Proyecto.API._Features.Municipios.Entities;

namespace AcademiaFS.Proyecto.API._Features.Departamentos.Entities
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
    }
}
