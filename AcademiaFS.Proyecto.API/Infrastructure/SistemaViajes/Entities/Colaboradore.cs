﻿using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API.Infrastructure;
using Farsiman.Application.Core.Standard.DTOs;
using FluentValidation;

namespace AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities
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

        public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

        public virtual ICollection<SucursalesXcolaboradore> SucursalesXcolaboradores { get; set; } = new List<SucursalesXcolaboradore>();

        public virtual Usuario UsuaCreacionNavigation { get; set; } = null!;

        public virtual Usuario? UsuaModificacionNavigation { get; set; }

        public virtual ICollection<ViajesDetalle> ViajesDetalles { get; set; } = new List<ViajesDetalle>();
    }

    public class ColaboradoreValidator : AbstractValidator<Colaboradore>
    {
        public ColaboradoreValidator()
        {
            RuleFor(r => r.Nombres).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombres"));
            RuleFor(r => r.Apellidos).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Apellidos"));
            RuleFor(r => r.Identidad).NotEmpty().MaximumLength(13).MinimumLength(13).WithMessage(Mensajes.LONGITUD_ERRONEA("Identidad", 13));
            RuleFor(r => r.Sexo).NotEmpty().MaximumLength(1).Must(x => x == "F" || x == "M").WithMessage(Mensajes.SEXO_INVALIDO);
            RuleFor(r => r.Direccion).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Dirección"));
            RuleFor(r => r.FechaNacimiento).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Fecha Nacimiento"));
            RuleFor(r => r.SucursalesXcolaboradores).Must(DistanciasValidas).WithMessage(Mensajes.DISTANCIA_SUCURSALES);
        }

        private bool DistanciasValidas(ICollection<SucursalesXcolaboradore> sucursalesXcolaboradores)
        {
            if (sucursalesXcolaboradores.Count != sucursalesXcolaboradores.Where(x => x.DistanciaKm > 0 && x.DistanciaKm < 51).ToList().Count)
                return false;
            else
                return true;
        }
    }
}
