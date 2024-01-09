using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados;
using AcademiaFS.EjemploUT2_Planillas.WebApi._Features.Empleados.Dtos;

namespace AcademiaFS.EjemploUT2_Planilla.UnitTest
{
    public class EmpleadoTests
    {
        private readonly EmpleadoDomainService empleadoDomainService;
        public EmpleadoTests()
        {
            empleadoDomainService = new EmpleadoDomainService();
        }

        [Fact]
        public void ValidarEmpleado_IsTrue()
        {
            //Arrange
            EmpleadoDto empleadoDto = new EmpleadoDto
            {
                Nombre = "Nombre",
                Identidad = "0501200506728",
                HorasTrabajadas = 176,
                PagoPorHora = 30
            };

            //Act 
            bool respuesta = empleadoDomainService.ValidarEmpleado(empleadoDto);

            //Assert
            Assert.True(respuesta);
        }

        [Fact]
        public void ValidarEmpleado_IsFalse()
        {
            //Arrange
            EmpleadoDto empleadoDto = new EmpleadoDto
            {
                Nombre = "Nombre",
                Identidad = "0501200",
                HorasTrabajadas = 176,
                PagoPorHora = 30
            };

            //Act 
            bool respuesta = empleadoDomainService.ValidarEmpleado(empleadoDto);

            //Assert
            Assert.False(respuesta);
        }

        [Fact]
        public void ObtenerSalarioBruto_Resultado()
        {
            //Arrange
            EmpleadoDto empleadoDto = new EmpleadoDto
            {
                Nombre = "Nombre",
                Identidad = "0501200506728",
                HorasTrabajadas = 176,
                PagoPorHora = 30
            };

            //Act 
            decimal respuesta = empleadoDomainService.ObtenerSalarioBruto(empleadoDto);

            //Assert
            Assert.Equal(5280m, respuesta);
        }

        [Fact]
        public void ObtenerDeducciones_Resultado()
        {
            //Arrange
            EmpleadoDto empleadoDto = new EmpleadoDto
            {
                Nombre = "Nombre",
                Identidad = "0501200506728",
                HorasTrabajadas = 44,
                PagoPorHora = 30
            };

            //Act 
            decimal respuesta = empleadoDomainService.ObtenerSalarioBruto(empleadoDto);

            //Assert
            Assert.Equal(158.4m, respuesta);
        }
    }
}