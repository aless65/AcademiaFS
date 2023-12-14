using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Transportistas._Models
{
    public class TransportistaDto
    {
        public int TranId { get; set; }

        public required string TranNombres { get; set; }

        public required string TranApellidos { get; set; }

        public required string TranIdentidad { get; set; }

        public decimal TranTarifaKm { get; set; }

        public DateTime TranFechaNacimiento { get; set; }

        public string? TranSexo { get; set; }

        public bool? TranEstado { get; set; }

        public int TranUsuaCreacion { get; set; }

        public DateTime TranFechaCreacion { get; set; }

        public int? TranUsuaModificacion { get; set; }

        public DateTime? TranFechaModificacion { get; set; }
    }
}
