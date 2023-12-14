namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeDto
    {
        public int ViajId { get; set; }

        public DateTime ViajFechaYHora { get; set; }

        public decimal ViajTotalKm { get; set; }

        public decimal ViajPagoTotal { get; set; }

        public int SucuId { get; set; }

        public int TranId { get; set; }

        public bool? ViajEstado { get; set; }

        public int ViajUsuaCreacion { get; set; }

        public DateTime ViajFechaCreacion { get; set; }

        public int? ViajUsuaModificacion { get; set; }

        public DateTime? ViajFechaModificacion { get; set; }

        public int Id { get; set; }
        public required string Nombre { get; set; }
        public bool Admin { get; set; }
    }
}
