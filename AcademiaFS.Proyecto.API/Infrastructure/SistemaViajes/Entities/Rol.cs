namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
{
    public class Rol
    {
        public int IdRol { get; set; }

        public required string Nombre { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
