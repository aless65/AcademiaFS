using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola._Common.Models
{
    public class Respuesta
    {
        public bool ok { get; set; }
        public string? codigo { get; set; }
        public string? mensaje { get; set; }
        public object? data { get; set; }
    }
}
