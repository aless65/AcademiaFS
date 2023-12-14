using AcademiaFS.Proyecto.Consola.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola._Common
{
    public enum RutaApi
    {
        [Ruta("https://localhost:7216/api/")]
        Maestros,
        [Ruta("")]
        Consumo,
    }
}
