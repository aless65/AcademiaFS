namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

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

        public virtual ICollection<Colaboradore> ColaboradoreUsuaCreacionNavigations { get; set; } = new List<Colaboradore>();
        public virtual ICollection<Colaboradore> ColaboradoreUsuaModificacionNavigations { get; set; } = new List<Colaboradore>();
        public virtual ICollection<Departamento> DepartamentoUsuaCreacionNavigations { get; set; } = new List<Departamento>();
        public virtual ICollection<Departamento> DepartamentoUsuaModificacionNavigations { get; set; } = new List<Departamento>();
        public virtual ICollection<Municipio> MunicipioUsuaCreacionNavigations { get; set; } = new List<Municipio>();
        public virtual ICollection<Municipio> MunicipioUsuaModificacionNavigations { get; set; } = new List<Municipio>();
        public virtual ICollection<Sucursale> SucursaleUsuaCreacionNavigations { get; set; } = new List<Sucursale>();
        public virtual ICollection<Sucursale> SucursaleUsuaModificacionNavigations { get; set; } = new List<Sucursale>();
        public virtual ICollection<SucursalesXcolaboradore> SucursalesXColaboradoreUsuaCreacionNavigations { get; set; } = new List<SucursalesXcolaboradore>();
        public virtual ICollection<Transportista> TransportistaUsuaCreacionNavigations { get; set; } = new List<Transportista>();
        public virtual ICollection<Transportista> TransportistaUsuaModificacionNavigations { get; set; } = new List<Transportista>();
        public virtual ICollection<Usuario> InverseUsuaCreacionNavigation { get; set; } = new List<Usuario>();

        public virtual ICollection<Usuario> InverseUsuaModificacionNavigation { get; set; } = new List<Usuario>();
        public virtual ICollection<Viaje>? ViajeUsuaCreacionNavigations { get; set; } = new List<Viaje>();
        public virtual ICollection<Viaje>? ViajeUsuaModificacionNavigations { get; set; } = new List<Viaje>();
        public virtual ICollection<ViajesDetalle> ViajesDetalleUsuaCreacionNavigations { get; set; } = new List<ViajesDetalle>();
        public virtual ICollection<ViajesDetalle> ViajesDetalleUsuaModificacionNavigations { get; set; } = new List<ViajesDetalle>();
        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }
    }
}
