
namespace AcademiaFS.Proyecto.API._Features.Sucursales.Dtos
{
    public class SucursaleListarDto
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; } = null!;
    }
}
