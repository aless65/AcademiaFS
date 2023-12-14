namespace AcademiaFS.Proyecto.API._Features.Usuarios.Entities
{
    public class RolesEntity
    {
        public int RolId { get; set; }

        public required string RolNombre { get; set; }

        public bool? RolEstado { get; set; }

        public int RolUsuaCreacion { get; set; }

        public DateTime RolFechaCreacion { get; set; }

        public int? RolUsuaModificacion { get; set; }
        public DateTime? RolFechaModificacion { get; set; }

        public virtual ICollection<UsuariosEntity> Usuarios { get; set; } = new List<UsuariosEntity>();
    }
}
