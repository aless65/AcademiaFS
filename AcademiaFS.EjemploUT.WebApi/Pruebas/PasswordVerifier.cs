namespace AcademiaFS.EjemploUT.WebApi.Pruebas
{
    public class PasswordVerifier
    {
        public (bool, string) ContrasenaFuerte(string password)
        {
            string respuesta = "";
            bool esValida = true;

            if (password.Length < 8)
            {
                respuesta += "Se necesitan más de 8 caracteres \n";
                esValida = false;
            }
            else
                respuesta += "Contiene más de 8 caracteres \n";

            if (!password.Any(char.IsUpper))
            {
                respuesta += "Se necesita al menos una mayúscula \n";
                esValida = false;
            }
            else
                respuesta += "Tiene al menos una mayúscula \n";

            if (!password.Any(char.IsLower))
            {
                respuesta += "Se necesita al menos una minúscula \n";
                esValida = false;
            }
            else
                respuesta += "Tiene al menos una minúscula \n";

            if (!password.Any(char.IsDigit))
            {
                respuesta += "Se necesita al menos un número \n";
                esValida = false;
            }
            else
                respuesta += "Tiene al menos un número \n";

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                respuesta += "Se necesita al menos un caracter especial \n";
                esValida = false;
            }
            else
                respuesta += "Tiene al menos un caracter especial \n";

            if (esValida)
                respuesta = "Contraseña fuerte \n" + respuesta;

            return (esValida, respuesta);
        }
    }
}
