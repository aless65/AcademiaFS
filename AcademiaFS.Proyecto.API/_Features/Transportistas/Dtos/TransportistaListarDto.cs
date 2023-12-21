namespace AcademiaFS.Proyecto.API._Features.Transportistas.Dtos
{
    public class TransportistaListarDto
    {
        public int IdTransportista { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public decimal TarifaKm { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;
    }
}
