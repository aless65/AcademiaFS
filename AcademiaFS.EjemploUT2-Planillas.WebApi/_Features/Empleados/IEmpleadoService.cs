using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;

namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados
{
    public interface IEmpleadoService
    {
        EmpleadoPlanillaDto ObtenerPlanilla(EmpleadoDto empleadoDto);
    }
}
