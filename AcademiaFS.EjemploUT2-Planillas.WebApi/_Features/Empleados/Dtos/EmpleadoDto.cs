namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos
{
    public class EmpleadoDto
    {
        public string Nombre { get; set; } = null!;
        public string Identidad { get; set; } = null!;
        public decimal PagoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }
    }
}
