namespace AcademiaFS.EjemploUT.WebApi.Pruebas
{
    public class CurrencyConverter
    {
        public decimal LempiraToDollar(decimal num1)
        {
            if (num1 < 0)
                throw new System.Exception("El numero no puede ser negativo");

            decimal conversion = num1 * 0.0405m;

            conversion = Math.Round(conversion, 2);

            return conversion; 
        }
    }
}
