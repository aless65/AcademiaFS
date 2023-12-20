﻿using AcademiaFS.Proyecto.API._Features.Viajes.Entities;

namespace AcademiaFS.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajeListarDto
    {
        public int IdViaje { get; set; }

        public DateTime FechaYhora { get; set; }

        public decimal TarifaActual { get; set; }

        public decimal TotalKm { get; set; }

        public int IdSucursal { get; set; }

        public string? NombreSucursal { get; set; }

        public int IdTransportista { get; set; }

        public string? NombreTransportista { get; set; }

        //Detalles 
        public List<ViajesDetalleListarDto>? ViajeDetalles { get; set; }
    }
}
