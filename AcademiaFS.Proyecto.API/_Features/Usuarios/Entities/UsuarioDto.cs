namespace AcademiaFS.Proyecto.API._Features.Usuarios.Entities
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Contrasena { get; set; }

        public string? Imagen { get; set; }

        public bool EsAdmin { get; set; }

        public int? IdRol { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
