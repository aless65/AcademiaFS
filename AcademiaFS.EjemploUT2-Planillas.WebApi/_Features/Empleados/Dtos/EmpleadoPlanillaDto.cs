namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos
{
    public class EmpleadoPlanillaDto
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Identidad { get; set; } = null!;
        public decimal HorasTrabajadas { get; set; }
        public decimal PagoPorHora { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal Deducciones { get; set; }
        public decimal SueldoAPagar { get; set; }
    }
}
