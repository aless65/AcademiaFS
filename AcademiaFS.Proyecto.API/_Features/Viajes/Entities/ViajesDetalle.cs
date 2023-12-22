using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Usuarios.Entities;
using System.Text.Json.Serialization;

namespace AcademiaFS.Proyecto.API._Features.Viajes.Entities
{
    public class ViajesDetalle
    {
        public int IdViajeDetalle { get; set; }

        public int IdViaje { get; set; }

        public int IdColaborador { get; set; }

        public decimal DistanciaActual { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Colaboradore? IdColaboradorNavigation { get; set; }

        public virtual Viaje IdViajeNavigation { get; set; } = null!;
        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }
    }
}
