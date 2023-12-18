using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;

//using Farsiman.Application.Core.Standard.DTOs;
using Microsoft.OpenApi.Any;
using System;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores
{
    public class ColaboradorService
    {
        private readonly SistemaViajesDBContext _db;

        public ColaboradorService(SistemaViajesDBContext db, IMapper mapper)
        {
            _db = db;
        }

        public List<Colaboradore> ListaColaboradores()
        {
            List<Colaboradore> Colaboradores = _db.Colaboradores.ToList();
            foreach (var item in Colaboradores)
            {
                item.SucursalesXcolaboradores = _db.SucursalesXColaboradores.Where(x => x.IdColaborador.Equals(item.IdColaborador)).ToList();
            }
            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(Colaboradore colaboradores)
        {
            try
            {
                if (colaboradores.SucursalesXcolaboradores.Count() != colaboradores.SucursalesXcolaboradores.Where(x => x.DistanciaKm > 0 && x.DistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");

                if (colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Count() !=
                    colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Distinct().Count())
                    return Respuesta.Fault<object>("No puede ingresar dos veces la misma sucursal");

                _db.Colaboradores.Add(colaboradores);

                foreach (var item in colaboradores.SucursalesXcolaboradores)
                {
                    item.IdColaborador = colaboradores.IdColaborador;
                }

                _db.SucursalesXColaboradores.AddRange(colaboradores.SucursalesXcolaboradores);

                _db.SaveChanges();

                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500"); 
            }
}
    }
}
 