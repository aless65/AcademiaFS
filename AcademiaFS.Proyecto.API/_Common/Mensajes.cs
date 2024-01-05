namespace AcademiaFS.Proyecto.API._Common
{
    public static class Mensajes
    {
        public const string PROCESO_EXITOSO = "Operación exitosa";
        public const string PROCESO_FALLIDO = "Error. Intente más tarde";
        public const string DATOS_INCORRECTOS = "Los datos se han enviado de forma incorrecta. Revise llaves foráneas, constraints, nulos, etc";
        public const string SEXO_INVALIDO = "El sexo debe ser F o M";
        //public const string CARACTERES_IDENTIDAD = "La identidad debe tener 13 caracteres";
        public static string OPERACION_EXITOSA(string nombreOperacion)
        {
            return $"El registro ha sido {nombreOperacion} correctamente";
        }

        public static string CAMPO_VACIO(string nombrePropiedad)
        {
            return $"El campo '{nombrePropiedad}' es requerido";
        }
        public static string LONGITUD_ERRONEA(string nombrePropiedad, int numeroCaracteres)
        {
            return $"El campo '{nombrePropiedad}' no cumple con el número de caracteres permitidos ({numeroCaracteres})";
        }
        public static string REPETIDO(string nombrePropiedad)
        {
            return $"Este(a) '{nombrePropiedad}' ya existe";
        }
        public static string NO_EXISTE(string nombrePropiedad)
        {
            return $"El/la '{nombrePropiedad}' no existe";
        }
    }
}
