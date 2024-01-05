﻿namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
{
    public class Rol
    {
        public int RolId { get; set; }

        public required string RolNombre { get; set; }

        public bool? RolEstado { get; set; }

        public int RolUsuaCreacion { get; set; }

        public DateTime RolFechaCreacion { get; set; }

        public int? RolUsuaModificacion { get; set; }
        public DateTime? RolFechaModificacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}