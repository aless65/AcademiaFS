namespace AcademiaFS.Proyecto.API._Features.Municipios.Dto
{
    public class MunicipioListarDto
    {
        public int IdMunicipio { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; } = null!;
    }
}
