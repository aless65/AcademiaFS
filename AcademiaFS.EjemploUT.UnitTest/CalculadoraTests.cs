using AcademiaFS.EjemploUT.WebApi.Pruebas;

namespace AcademiaFS.EjemploUT.UnitTest
{
    public class CalculadoraTests
    {
        private Calculadora calculator;

        public CalculadoraTests()
        {
            calculator = new Calculadora();
        }

        [Fact]
        public void Add_ShouldReturnSum()
        {
            // Arrange 
            decimal num1 = 8;
            decimal num2 = 10;

            //Act 
            decimal result = calculator.Sumar(num1, num2);

            //Assert
            Assert.Equal(18, result);
        }

        [Fact]
        public void Substract_ShouldReturnDifference()
        {
            // Arrange 
            decimal num1 = 10;
            decimal num2 = 8;

            //Act 
            decimal result = calculator.Restar(num1, num2);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Multiply_ShouldReturnProduct()
        {
            // Arrange 
            decimal num1 = 10;
            decimal num2 = 8;

            //Act 
            decimal result = calculator.Multiplicar(num1, num2);

            //Assert
            Assert.Equal(80, result);
        }

        [Fact]
        public void Divide_ShouldReturnResult()
        {
            // Arrange 
            decimal num1 = 10;
            decimal num2 = 8;

            //Act 
            decimal result = calculator.Dividir(num1, num2);

            //Assert
            Assert.Equal((decimal)1.25, result);
        }

        //[Fact]
        //public void Divide_ShouldReturnResultWhen0()
        //{
        //    // Arrange 
        //    decimal num1 = 10;
        //    decimal num2 = 0;

        //    //Act 
        //    decimal result = calculator.Dividir(num1, num2);

        //    //Assert
        //    Assert.Equal(0, result);
        //}

        [Fact]
        public void Divide_ShouldThrowExceptionWhen0()
        {
            // Arrange 
            decimal num1 = 10;
            decimal num2 = 0;

            //Act and Assert
            Assert.Throws<System.DivideByZeroException>(() => calculator.Dividir(num1, num2));
        }
    }
}