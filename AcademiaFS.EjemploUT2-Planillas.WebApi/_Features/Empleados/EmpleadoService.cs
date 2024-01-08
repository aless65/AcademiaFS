using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;

namespace AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly EmpleadoDomainService _empleadoDomainService;

        public EmpleadoService(EmpleadoDomainService empleadoDomainService)
        {
            _empleadoDomainService = empleadoDomainService;
        }
        public (EmpleadoPlanillaDto, string) ObtenerPlanilla(EmpleadoDto empleadoDto)
        {
            EmpleadoPlanillaDto empleadoPlanillaDto = new();

            if (_empleadoDomainService.ValidarEmpleado(empleadoDto))
                return (empleadoPlanillaDto, "Datos inválidos");

            throw new NotImplementedException();
        }
    }
}
