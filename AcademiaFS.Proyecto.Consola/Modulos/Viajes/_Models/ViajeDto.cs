using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Viajes._Models
{
    public class ViajeDto
    {
        public int ViajId { get; set; }

        public DateTime ViajFechaYHora { get; set; }

        public decimal ViajTotalKm { get; set; }

        public decimal ViajTarifaActual { get; set; }

        public int SucuId { get; set; }

        public int TranId { get; set; }

        public bool? ViajEstado { get; set; }

        public int ViajUsuaCreacion { get; set; }

        public DateTime ViajFechaCreacion { get; set; }

        public int? ViajUsuaModificacion { get; set; }

        public DateTime? ViajFechaModificacion { get; set; }
        public List<ViajeDetallesDto>? ViajeDetalles { get; set; }

        public bool admin { get; set; }
    }
}
