namespace AcademiaFS.Proyecto.API._Features.EstadosCiviles.Entities
{
    public class EstadoCivil
    {
        public int IdEstadoCivil { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
