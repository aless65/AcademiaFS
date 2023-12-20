namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajesDetalleListarDto
    {
        public int IdViajeDetalle { get; set; }

        public int IdViaje { get; set; }

        public int IdColaborador { get; set; }

        public string? ColaboradorNombre { get; set; }

        public decimal DistanciaActual { get; set; }
    }
}
