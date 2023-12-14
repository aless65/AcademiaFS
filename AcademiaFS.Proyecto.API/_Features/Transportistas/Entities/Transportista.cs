namespace AcademiaFS.Proyecto.API._Features.Transportistas.Entities
{
    public class Transportista
    {
        public int TranId { get; set; }

        public required string TranNombres { get; set; }

        public required string TranApellidos { get; set; }

        public required string TranIdentidad { get; set; }

        public decimal TranTarifaKm { get; set; }

        public DateTime TranFechaNacimiento { get; set; }

        public string? TranSexo { get; set; }

        public bool? TranEstado { get; set; }

        public int TranUsuaCreacion { get; set; }

        public DateTime TranFechaCreacion { get; set; }

        public int? TranUsuaModificacion { get; set; }

        public DateTime? TranFechaModificacion { get; set; }
    }
}
