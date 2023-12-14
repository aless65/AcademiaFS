using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
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

        public List<Colaborador> ListaColaboradores()
        {
            List<Colaborador> Colaboradores = _db.Colaboradores.ToList();
            foreach (var item in Colaboradores)
            {
                item.sucursalesXColaboradores = _db.SucursalesXColaboradores.Where(x => x.ColId.Equals(item.ColId)).ToList();
            }
            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(Colaborador colaboradores)
        {
            try
            {
                if (colaboradores.sucursalesXColaboradores.Count() != colaboradores.sucursalesXColaboradores.Where(x => x.SucoDistanciaKm > 0 && x.SucoDistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");

                if (colaboradores.sucursalesXColaboradores.Select(g => g.SucuId).Count() !=
                    colaboradores.sucursalesXColaboradores.Select(g => g.SucuId).Distinct().Count())
                    return Respuesta.Fault<object>("No puede ingresar dos veces la misma sucursal");

                _db.Colaboradores.Add(colaboradores);

                foreach (var item in colaboradores.sucursalesXColaboradores)
                {
                    item.ColId = colaboradores.ColId;
                }

                _db.SucursalesXColaboradores.AddRange(colaboradores.sucursalesXColaboradores);

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
 