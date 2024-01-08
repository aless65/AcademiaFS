namespace AcademiaFS.EjemploUT.WebApi.Entities
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identidad { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public string Celular { get; set; } = null!;
    }
}
