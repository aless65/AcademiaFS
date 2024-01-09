using AcademiaFS.EjemploUT2_Planillas.WebApi._Common;
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

            salarioBruto = Math.Round(salarioBruto, 2);

            return salarioBruto;
        }

        public decimal ObtenerDeducciones(decimal salarioBruto)
        {
            decimal seguroSocial = salarioBruto * Deducciones.SeguroSocial;
            decimal seguroEducativo = salarioBruto * Deducciones.SeguroEducativo;
            decimal impuestoSobreLaRenta = salarioBruto * Deducciones.ImpuestoSobreLaRenta;

            decimal totalDeducciones = seguroSocial + seguroEducativo + impuestoSobreLaRenta;

            totalDeducciones = Math.Round(totalDeducciones, 2);

            return totalDeducciones;
        }
    }
}
