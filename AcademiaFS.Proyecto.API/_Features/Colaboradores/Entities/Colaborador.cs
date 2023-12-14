
namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Entities
{
    public class Colaborador
    {
        public int ColId { get; set; }

        public required string ColNombres { get; set; }

        public required string ColApellidos { get; set; }

        public required string ColIdentidad { get; set; }

        public required string ColDireccion { get; set; }

        public int MuniId { get; set; }

        public DateTime ColFechaNacimiento { get; set; }

        public required string ColSexo { get; set; }

        public bool? ColEstado { get; set; }

        public int ColUsuaCreacion { get; set; }

        public DateTime ColFechaCreacion { get; set; }

        public int? ColUsuaModificacion { get; set; }

        public DateTime? ColFechaModificacion { get; set; }

        public List<SucursalXColaborador>? sucursalesXColaboradores { get; set; }
    }
}


//using System.ComponentModel.DataAnnotations.Schema;

//namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Entities
//{
//    public class tbColaboradores
//    {
//        public int ColId { get; set; }

//        public required string ColNombres { get; set; }

//        public required string ColApellidos { get; set; }

//        public required string ColIdentidad { get; set; }

//        public required string ColDireccion { get; set; }

//        public int muni_Id { get; set; }

//        public DateTime ColFechaNacimiento { get; set; }

//        public required string ColSexo { get; set; }

//        public bool? ColEstado { get; set; }

//        public int ColUsuaCreacion { get; set; }

//        public DateTime ColFechaCreacion { get; set; }

//        public int? ColUsuaModificacion { get; set; }

//        public DateTime? ColFechaModificacion { get; set; }

//        public List<tbSucursalesXColaboradores>? sucursalesXColaboradores { get; set; }

//        //[NotMapped]
//        //public string muni_Codigo { get; set; }

//        //[NotMapped]
//        //public string muni_Nombre { get; set; }

//        //[NotMapped]
//        //public string sucursales { get; set; }

//        //[NotMapped]
//        //public decimal suco_DistanciaKm { get; set; }

//        //[NotMapped]
//        //public string usuarioCreacion { get; set; }

//        //[NotMapped]
//        //public string usuarioModificacion { get; set; }


//        //public virtual tbUsuarios ColUsuaCreacionNavigation { get; set; }

//        //public virtual tbUsuarios ColUsuaModificacionNavigation { get; set; }

//        //public virtual tbMunicipios muni { get; set; }

//        //public virtual ICollection<tbSucursalesXColaboradores> tbSucursalesXColaboradores { get; set; } = new List<tbSucursalesXColaboradores>();

//        //public virtual ICollection<tbViajesDetalles> tbViajesDetalles { get; set; } = new List<tbViajesDetalles>();
//    }
//}
