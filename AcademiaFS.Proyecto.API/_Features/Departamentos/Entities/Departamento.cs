using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Municipios.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using FluentValidation;

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
        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
    }

    public class DepartamentoValidator : AbstractValidator<Departamento>
    {
        public DepartamentoValidator()
        {
            RuleFor(r => r.Codigo).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Código")).MinimumLength(2).MaximumLength(2).WithMessage(Mensajes.LONGITUD_ERRONEA("Codigo", 2));
            RuleFor(r => r.Nombre).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombre"));
        }
    }
}
