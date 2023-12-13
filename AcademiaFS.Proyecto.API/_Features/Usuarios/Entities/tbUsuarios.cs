namespace AcademiaFS.Proyecto.API._Features.Usuarios.Entities
{
    public class tbUsuarios
    {
        public int usua_Id { get; set; }

        public required string usua_Nombre { get; set; }

        public required string usua_Contrasena { get; set; }

        public string? usua_Imagen { get; set; }

        public bool usua_EsAdmin { get; set; }

        public int? role_Id { get; set; }

        public bool? usua_Estado { get; set; }

        public int usua_UsuaCreacion { get; set; }

        public DateTime usua_FechaCreacion { get; set; }

        public int? usua_UsuaModificacion { get; set; }

        public DateTime? usua_FechaModificacion { get; set; }
    }
}
