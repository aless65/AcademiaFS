using AcademiaFS.EjemploUT2_Planillas.WebApi._Common;
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
        public Respuesta ObtenerPlanilla(EmpleadoDto empleadoDto)
        {
            EmpleadoPlanillaDto empleadoPlanillaDto;
            Respuesta respuesta = new();

            if (!_empleadoDomainService.ValidarEmpleado(empleadoDto))
            {
                respuesta.Mensaje = "Datos inválidos";
                return respuesta;

            }

            decimal salarioBruto = _empleadoDomainService.ObtenerSalarioBruto(empleadoDto);
            decimal deducciones = _empleadoDomainService.ObtenerDeducciones(salarioBruto);

            empleadoPlanillaDto = new EmpleadoPlanillaDto
            {
                Nombre = empleadoDto.Nombre,
                Identidad = empleadoDto.Identidad,
                PagoPorHora = empleadoDto.PagoPorHora,
                HorasTrabajadas = empleadoDto.HorasTrabajadas,
                SalarioBruto = salarioBruto,
                Deducciones = deducciones,
                SueldoAPagar = salarioBruto - deducciones
            };

            respuesta.Mensaje = "Operación completada exitosamente";
            respuesta.Objeto = empleadoPlanillaDto;
            return respuesta;
        }
    }
}
