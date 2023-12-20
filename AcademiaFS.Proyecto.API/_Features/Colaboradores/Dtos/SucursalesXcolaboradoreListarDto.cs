namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos
{
    public class SucursalesXcolaboradoreListarDto
    {
        public int IdSucursalXcolaborador { get; set; }

        public int IdSucursal { get; set; }

        public string NombreSucursal { get; set; } = null!;

        public int IdColaborador { get; set; }

        public string NombreColaborador { get; set; } = null!;

        public decimal DistanciaKm { get; set; }
    }
}
