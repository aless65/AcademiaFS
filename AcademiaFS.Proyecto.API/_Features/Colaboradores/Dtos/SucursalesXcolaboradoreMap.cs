namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos
{
    public class SucursalesXcolaboradoreMap
    {
        public int IdSucursalXcolaborador { get; set; }

        public int IdSucursal { get; set; }

        public int IdColaborador { get; set; }

        public decimal DistanciaKm { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
