
namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeDto
    {
        public int IdViaje { get; set; }

        public DateTime FechaYhora { get; set; }

        public int IdSucursal { get; set; }

        public int IdTransportista { get; set; }

        //Detalles 
        public List<ViajesDetalleDto> ViajesDetalles { get; set; } = new List<ViajesDetalleDto>();

        //Info de usuario
        public bool Admin { get; set; }
    }
}
