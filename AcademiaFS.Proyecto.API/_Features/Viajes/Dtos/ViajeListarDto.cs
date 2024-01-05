
namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeListarDto
    {
        public int IdViaje { get; set; }

        public DateTime FechaYhora { get; set; }

        public decimal TarifaActual { get; set; }

        public decimal TotalKm { get; set; }

        public int IdSucursal { get; set; }

        public string? NombreSucursal { get; set; }

        public int IdTransportista { get; set; }

        public string? NombreTransportista { get; set; }

        public decimal TotalPagar { get; set; }

        //Detalles 
        public List<ViajesDetalleListarDto> ViajesDetalles { get; set; } = new List<ViajesDetalleListarDto>();
    }
}
