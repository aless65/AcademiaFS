
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Departamentos.Entities;
using AcademiaFS.Proyecto.API._Features.Municipios.Entities;
using AcademiaFS.Proyecto.API._Features.Roles.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace AcademiaFS.Proyecto.API._Features.Usuarios.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Contrasena { get; set; }

        public string? Imagen { get; set; }

        public bool EsAdmin { get; set; }

        public int? IdRol { get; set; }

        public bool? Estado { get; set; }

        public int UsuaCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuaModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Rol? role { get; set; }

        public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
        public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
        public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
        public virtual ICollection<SucursalesXcolaboradore> SucursalesXColaboradores { get; set; } = new List<SucursalesXcolaboradore>();
        public virtual ICollection<Transportista> Transportistas { get; set; } = new List<Transportista>();
        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
        public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
    }
}
