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

        public required string Nombre { get; set; }

        public required string Contrasena { get; set; }

        public string? Imagen { get; set; }

        public bool Admin { get; set; }

        public int? rolId { get; set; }
    }
}
