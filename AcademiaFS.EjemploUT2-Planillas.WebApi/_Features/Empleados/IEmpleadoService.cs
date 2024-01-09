using AcademiaFS.EjemploUT2_Planillas.WebApi._Common;
using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;

namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados
{
    public interface IEmpleadoService
    {
        Respuesta ObtenerPlanilla(EmpleadoDto empleadoDto);
    }
}
