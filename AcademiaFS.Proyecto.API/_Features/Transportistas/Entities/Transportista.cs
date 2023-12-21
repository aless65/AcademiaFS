using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using FluentValidation;

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
        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }

    public class TransportistaValidator : AbstractValidator<Transportista>
    {
        public TransportistaValidator() 
        {
            RuleFor(r => r.Nombres).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombres"));
            RuleFor(r => r.Apellidos).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Apellidos"));
            RuleFor(r => r.Identidad).NotEmpty().MaximumLength(13).MinimumLength(13).WithMessage(Mensajes.LONGITUD_ERRONEA("Identidad", 13));
            RuleFor(r => r.Sexo).NotEmpty().MaximumLength(1).Must(x => x == "F" || x == "M").WithMessage(Mensajes.SEXO_INVALIDO);
            RuleFor(r => r.TarifaKm).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Tarifa Km")).GreaterThan(0);
            RuleFor(r => r.FechaNacimiento).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Fecha Nacimiento"));
        }
    }
}
