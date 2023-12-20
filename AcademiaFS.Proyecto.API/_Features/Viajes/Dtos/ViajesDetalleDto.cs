namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajesDetalleDto
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

    }
}
