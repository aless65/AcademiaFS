using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;

namespace AcademiaFS.Proyecto.API._Features.Viajes.Entities
{
    public class Viaje
    {
        public int IdViaje { get; set; }

        public DateTime FechaYhora { get; set; }

        public decimal TarifaActual { get; set; }

        public decimal TotalKm { get; set; }

        public int IdSucursal { get; set; }

        public int IdTransportista { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

        public virtual Transportista IdTransportistaNavigation { get; set; } = null!;

        //public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        //public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<ViajesDetalle>? ViajesDetalles { get; set; } = new List<ViajesDetalle>();
    }
}
