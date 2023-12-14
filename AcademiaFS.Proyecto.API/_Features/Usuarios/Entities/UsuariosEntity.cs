
namespace AcademiaFS.Proyecto.API._Features.Usuarios.Entities
{
    public class UsuariosEntity
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Contrasena { get; set; }

        public string? Imagen { get; set; }

        public bool Admin { get; set; }

        public int? rolId { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual RolesEntity? role { get; set; }
    }
}
