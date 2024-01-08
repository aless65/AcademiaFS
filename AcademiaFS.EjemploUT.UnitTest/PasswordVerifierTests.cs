using AcademiaFS.EjemploUT.WebApi.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.EjemploUT.UnitTest
{
    public class PasswordVerifierTests
    {
        private readonly PasswordVerifier passwordVerifier;

        public PasswordVerifierTests()
        {
            passwordVerifier = new PasswordVerifier();
        }

        [Fact]
        public void VerifyPassword_Correct()
        {
            // Arrange 
            string password = "Unmillion06!";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Contraseña fuerte", result);
            Assert.True(esValida);
        }

        [Fact]
        public void VerifyPassword_TooShort()
        {
            // Arrange 
            string password = "papa";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Se necesitan más de 8 caracteres", result);
            Assert.False(esValida);
        }

        [Fact]
        public void VerifyPassword_NeedsUpper()
        {
            // Arrange 
            string password = "unmillion";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Se necesita al menos una mayúscula", result);
            Assert.False(esValida);
        }

        [Fact]
        public void VerifyPassword_NeedsLower()
        {
            // Arrange 
            string password = "UNMILLION";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Se necesita al menos una minúscula", result);
            Assert.False(esValida);
        }

        [Fact]
        public void VerifyPassword_NeedsDigit()
        {
            // Arrange 
            string password = "Unmillion";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Se necesita al menos un número", result);
            Assert.False(esValida);
        }

        [Fact]
        public void VerifyPassword_NeedsSpecialCharacter()
        {
            // Arrange 
            string password = "Unmillion06";

            //Act 
            (bool esValida, string result) = passwordVerifier.ContrasenaFuerte(password);

            //Assert
            Assert.Contains("Se necesita al menos un caracter especial", result);
            Assert.False(esValida);
        }
    }
}
