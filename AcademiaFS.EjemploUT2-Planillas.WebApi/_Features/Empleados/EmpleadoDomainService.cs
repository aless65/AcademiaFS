using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;

namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados
{
    public class EmpleadoDomainService
    {
        public bool ValidarEmpleado (EmpleadoDto empleadoDto)
        {
            if(empleadoDto.Identidad.Length != 13)
                return false;

            if (empleadoDto.HorasTrabajadas < 1)
                return false;

            if (empleadoDto.PagoPorHora < 1)
                return false;

            return true;
        }

        public decimal ObtenerSalarioBruto(EmpleadoDto empleadoDto)
        {
            decimal salarioBruto = empleadoDto.PagoPorHora * empleadoDto.HorasTrabajadas;

            return salarioBruto;
        }

        public decimal ObtenerDeducciones(decimal salarioBruto)
        {
            decimal seguroSocial = salarioBruto * 0.0975m;
            decimal seguroEducativo = salarioBruto * 0.0125m;
            decimal impuestoSobreLaRenta = salarioBruto * 0.010m;

            decimal totalDeducciones = seguroSocial + seguroEducativo + impuestoSobreLaRenta;

            return totalDeducciones;
        }
    }
}
