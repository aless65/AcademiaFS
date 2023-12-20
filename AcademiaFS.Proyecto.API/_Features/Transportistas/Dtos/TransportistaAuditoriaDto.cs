namespace AcademiaFS.Proyecto.API._Features.Transportistas.Dtos
{
    public class TransportistaAuditoriaDto
    {
        public int IdTransportista { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public decimal TarifaKm { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public bool Estado { get; set; }

        public int UsuaCreacion { get; set; }
        public string? UsuaCreacionNombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public string? UsuaModificacionNombre { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
