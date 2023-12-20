namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos
{
    public class ColaboradoreListarDto
    {
        public int IdColaborador { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }

        public string NombreMunicipio { get; set;} = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public virtual ICollection<SucursalesXcolaboradoreListarDto>? SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradoreListarDto>();
    }
}
