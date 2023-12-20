using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace AcademiaFS.Proyecto.API._Features.Transportistas.Entities
{
    public class Transportista
    {
        public int IdTransportista { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public decimal TarifaKm { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public bool Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        //public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        //public virtual Usuario? UsuaModificacionNavigation { get; set; }

        //public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
