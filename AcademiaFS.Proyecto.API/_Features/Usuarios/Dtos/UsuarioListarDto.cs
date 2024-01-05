namespace AcademiaFS.Proyecto.API._Features.Usuarios.Dtos
{
    public class UsuarioListarDto
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; } 

        public int? IdRol { get; set; }

        public string? NombreRol { get; set; }

        public bool EsAdmin { get; set; }
    }
}
