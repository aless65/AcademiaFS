using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeDto
    {
        public int IdViaje { get; set; }

        public DateTime FechaYhora { get; set; }

        public decimal TarifaActual { get; set; }

        public decimal TotalKm { get; set; }

        public int IdSucursal { get; set; }

        public int IdTransportista { get; set; }

        //Detalles 
        public List<ViajeListarDetalleDto>? ViajesDetalles { get; set; } = new List<ViajeListarDetalleDto>();

        //Info de usuario
        public bool Admin { get; set; }
    }
}
