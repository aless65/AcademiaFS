using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
using Farsiman.Application.Core.Standard.DTOs;
using Microsoft.OpenApi.Any;
using System;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores
{
    public class ColaboradorService
    {
        private readonly SistemaViajesDBContext _db;

        public ColaboradorService(SistemaViajesDBContext db)
        {
            _db = db;
        }

        public List<tbColaboradores> ListaColaboradores()
        {
            List<tbColaboradores> Colaboradores = _db.Colaboradores.ToList();
            foreach (var item in Colaboradores)
            {
                item.sucursalesXColaboradores = _db.SucursalesXColaboradores.Where(x => x.cola_Id.Equals(item.cola_Id)).ToList();
            }
            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(tbColaboradores colaboradores)
        {
            try
            {
                //foreach (var item in colaboradores.sucursalesXColaboradores)
                //{
                //    if(item.suco_DistanciaKm < 1 || item.suco_DistanciaKm > 50)
                //    {
                //        return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");
                //    }
                        
                //}

                if (colaboradores.sucursalesXColaboradores.Count() != colaboradores.sucursalesXColaboradores.Where(x => x.suco_DistanciaKm > 0 && x.suco_DistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");

                if (colaboradores.sucursalesXColaboradores.Count() == colaboradores.sucursalesXColaboradores.GroupBy(i => new {i.sucu_Id})
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .Count())
                    return Respuesta.Fault<object>("No puede ingresar dos veces la misma sucursal");

                _db.Colaboradores.Add(colaboradores);

                _db.SucursalesXColaboradores.AddRange(colaboradores.sucursalesXColaboradores);

                _db.SaveChanges();

                return Respuesta.Success<object>(_db.SucursalesXColaboradores.ToList(), "Operación exitosa", "200"); 
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }
    }
}
 