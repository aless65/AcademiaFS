using AcademiaFS.EjemploUT.WebApi.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.EjemploUT.UnitTest
{
    public class CurrencyConverterTests
    {
        private CurrencyConverter converter;

        public CurrencyConverterTests()
        {
            converter = new CurrencyConverter();
        }

        [Fact]
        public void LempiraToDollar_ShouldReturnDollars()
        {
            // Arrange 
            decimal num1 = 42.99m;

            //Act 
            decimal result = converter.LempiraToDollar(num1);

            //Assert
            Assert.Equal(1.74m, result);
        }

        [Fact]
        public void LempiraToDollar_ShouldReturnDollarsNegativo()
        {
            // Arrange 
            decimal num1 = -50.10m;

            //Act and Assert
            Assert.Throws<System.Exception>(() => converter.LempiraToDollar(num1));
        }

    }
}
