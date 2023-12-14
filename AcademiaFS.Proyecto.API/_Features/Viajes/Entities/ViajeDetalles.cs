namespace AcademiaFS.Proyecto.API._Features.Viajes.Entities
{
    public class ViajeDetalles
    {
        public int VideId { get; set; }

        public int ViajId { get; set; }

        public int ColId { get; set; }

        public decimal VideDistancia { get; set; }

        public bool? VideEstado { get; set; }

        public int VideUsuaCreacion { get; set; }

        public DateTime VideFechaCreacion { get; set; }

        public int? VideUsuaModificacion { get; set; }

        public DateTime? VideFechaModificacion { get; set; }
    }
}
