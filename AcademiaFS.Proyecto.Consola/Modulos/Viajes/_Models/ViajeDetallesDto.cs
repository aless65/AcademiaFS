using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Viajes._Models
{
    public class ViajeDetallesDto
    {
        public int VideId { get; set; }

        public int ViajId { get; set; }

        public int ColId { get; set; }

        public decimal VideDistancia { get; set; }

        public bool? VideEstado { get; set; }

        public int VideUsuaCreacion { get; set; }

        public DateTime VideFechaCreacion { get; set; }

        public int? VideUsuaModificacion { get; set; }

        public DateTime? VideFechaModificacion { get; set; }
    }
}
