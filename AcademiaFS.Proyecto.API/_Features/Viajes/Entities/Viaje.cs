﻿namespace AcademiaFS.Proyecto.API._Features.Viajes.Entities
{
    public class Viaje
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
        public List<ViajeDetalles>? ViajeDetalles { get; set; }
    }
}