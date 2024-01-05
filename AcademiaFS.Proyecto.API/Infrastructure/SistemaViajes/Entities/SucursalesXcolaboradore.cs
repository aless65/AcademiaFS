using System.Text.Json.Serialization;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
{
    public class SucursalesXcolaboradore
    {
        public int IdSucursalXcolaborador { get; set; }

        public int IdSucursal { get; set; }

        public int IdColaborador { get; set; }

        public decimal DistanciaKm { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Colaboradore IdColaboradorNavigation { get; set; } = null!;

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;
    }
}
