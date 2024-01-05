using AcademiaFS.Proyecto.API._Common;
using FluentValidation;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int IdDepartamento { get; set; }

        public bool Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
        public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();

    }

    public class MunicipioValidator : AbstractValidator<Municipio>
    {
        public MunicipioValidator()
        {
            RuleFor(r => r.Codigo).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Código")).MinimumLength(4).MaximumLength(4).WithMessage(Mensajes.LONGITUD_ERRONEA("Codigo", 4));
            RuleFor(r => r.Nombre).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombre"));
            RuleFor(r => r.IdDepartamento).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Departamento"));
        }
    }
}
