using AcademiaFS.Proyecto.API._Common;
using FluentValidation;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
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

        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
    }

    public class ViajeValidator : AbstractValidator<Viaje>
    {
        public ViajeValidator()
        {
            RuleFor(r => r.FechaYhora).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombres"));
            RuleFor(r => r.TarifaActual).NotEmpty().GreaterThan(0);
            RuleFor(r => r.TotalKm).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
        }
    }
}
