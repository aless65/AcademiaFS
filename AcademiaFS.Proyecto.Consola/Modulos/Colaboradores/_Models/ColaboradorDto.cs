using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaFS.Proyecto.Consola.Modulos.Colaboradores._Models
{
    public class ColaboradorDto
    {
        public int ColId { get; set; }

        public string? ColNombres { get; set; }

        public string? ColApellidos { get; set; }

        public string? ColIdentidad { get; set; }

        public string? ColDireccion { get; set; }

        public int MuniId { get; set; }

        public DateTime ColFechaNacimiento { get; set; }

        public string? ColSexo { get; set; }

        public bool? ColEstado { get; set; }

        public int ColUsuaCreacion { get; set; }

        public DateTime ColFechaCreacion { get; set; }

        public int? ColUsuaModificacion { get; set; }

        public DateTime? ColFechaModificacion { get; set; }

        public List<SucursalXColaboradorDto>? sucursalesXColaboradores { get; set; }
    }
}
