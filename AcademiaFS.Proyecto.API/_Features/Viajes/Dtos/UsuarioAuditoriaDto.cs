namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class UsuarioAuditoriaDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public bool Admin { get; set; }
    }
}
