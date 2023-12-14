namespace AcademiaFS.Proyecto.API._Features.Sucursales.Entities
{
    public class Sucursal
    {
        public int SucuId { get; set; }

        public required string SucuNombre { get; set; }

        public required string SucuDireccion { get; set; }

        public int MuniId { get; set; }

        public bool? SucuEstado { get; set; }

        public int SucuUsuaCreacion { get; set; }

        public DateTime SucuFechaCreacion { get; set; }

        public int? SucuUsuaModificacion { get; set; }

        public DateTime? SucuFechaModificacion { get; set; }
    }
}
