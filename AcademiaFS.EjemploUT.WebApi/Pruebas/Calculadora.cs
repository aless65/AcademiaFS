namespace AcademiaFS.EjemploUT.WebApi.Pruebas
{
    public class Calculadora
    {
        public decimal Sumar(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
        public decimal Restar(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
        public decimal Multiplicar(decimal num1, decimal num2)
        {
            return num1 * num2;
        }
        //public decimal Dividir(decimal num1, decimal num2)
        //{
        //    if(num1 == 0 || num2 == 0) 
        //        return 0;

        //    return num1 / num2;
        //}

        public decimal Dividir(decimal num1, decimal num2)
        {
            if (num1 == 0 || num2 == 0)
                throw new System.DivideByZeroException("No se puede dividir entre 0");
            
            return num1 / num2;
        }
    }
}
