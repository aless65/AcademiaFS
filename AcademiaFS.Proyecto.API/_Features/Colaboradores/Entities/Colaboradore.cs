
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Entities
{
    public class Colaboradore
    {
        public int IdColaborador { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public int IdMunicipio { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        //public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

        public virtual ICollection<SucursalesXcolaboradore> SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradore>();

        //public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        //public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
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
