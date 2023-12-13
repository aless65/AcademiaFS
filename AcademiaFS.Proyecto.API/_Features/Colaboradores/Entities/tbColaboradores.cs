﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores.Entities
{
    public class tbColaboradores
    {
        public int cola_Id { get; set; }

        public required string cola_Nombres { get; set; }

        public required string cola_Apellidos { get; set; }

        public required string cola_Identidad { get; set; }

        public required string cola_Direccion { get; set; }

        public int muni_Id { get; set; }

        public DateTime cola_FechaNacimiento { get; set; }

        public required string cola_Sexo { get; set; }

        public bool? cola_Estado { get; set; }

        public int cola_UsuaCreacion { get; set; }

        public DateTime cola_FechaCreacion { get; set; }

        public int? cola_UsuaModificacion { get; set; }

        public DateTime? cola_FechaModificacion { get; set; }

        public float cantidadKm { get; set; }

        //[NotMapped]
        //public string muni_Codigo { get; set; }

        //[NotMapped]
        //public string muni_Nombre { get; set; }

        //[NotMapped]
        //public string sucursales { get; set; }

        //[NotMapped]
        //public decimal suco_DistanciaKm { get; set; }

        //[NotMapped]
        //public string usuarioCreacion { get; set; }

        //[NotMapped]
        //public string usuarioModificacion { get; set; }


        //public virtual tbUsuarios cola_UsuaCreacionNavigation { get; set; }

        //public virtual tbUsuarios cola_UsuaModificacionNavigation { get; set; }

        //public virtual tbMunicipios muni { get; set; }

        //public virtual ICollection<tbSucursalesXColaboradores> tbSucursalesXColaboradores { get; set; } = new List<tbSucursalesXColaboradores>();

        //public virtual ICollection<tbViajesDetalles> tbViajesDetalles { get; set; } = new List<tbViajesDetalles>();
    }
}
