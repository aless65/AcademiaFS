namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeReporteRangoFechaDto
    {
        public decimal totalAPagar { get; set; }

        public int IdTransportista { get; set; }
        public string NombreTransportista { get; set; } = null!;
        public object? reporte { get; set; }
        
    }
}
