using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola._Common.Models
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Contrasena { get; set; }

        public string? Imagen { get; set; }

        public bool Admin { get; set; }

        public int? rolId { get; set; }
    }
}
