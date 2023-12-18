using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace AcademiaFS.Proyecto.API._Features.Sucursales.Entities
{
    public class Sucursale
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        //public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

        //public virtual ICollection<SucursalesXcolaboradore> SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradore>();

        //public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        //public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
