using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
//using Farsiman.Application.Core.Standard.DTOs;
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

        public List<ColaboradoresEntity> ListaColaboradores()
        {
            List<ColaboradoresEntity> Colaboradores = _db.Colaboradores.ToList();
            foreach (var item in Colaboradores)
            {
                item.sucursalesXColaboradores = _db.SucursalesXColaboradores.Where(x => x.cola_Id.Equals(item.ColId)).ToList();
            }
            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(ColaboradoresEntity colaboradores)
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

                if (colaboradores.sucursalesXColaboradores.Select(g => g.sucu_Id).Count() !=
                    colaboradores.sucursalesXColaboradores.Select(g => g.sucu_Id).Distinct().Count())
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

        //public string InsertarColaboradores(tbColaboradores colaboradores)
        //{
        //    try
        //    {
        //        //foreach (var item in colaboradores.sucursalesXColaboradores)
        //        //{
        //        //    if(item.suco_DistanciaKm < 1 || item.suco_DistanciaKm > 50)
        //        //    {
        //        //        return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");
        //        //    }

        //        //}

        //        if (colaboradores.sucursalesXColaboradores.Count() != colaboradores.sucursalesXColaboradores.Where(x => x.suco_DistanciaKm > 0 && x.suco_DistanciaKm < 51).ToList().Count())
        //            return "Todas las distancias deben ser mayor que 0 y menor que 50";

        //        var prueba = colaboradores.sucursalesXColaboradores.Select(g => g.sucu_Id).ToList();

        //        if (colaboradores.sucursalesXColaboradores.Select(g => g.sucu_Id).Count() != 
        //            colaboradores.sucursalesXColaboradores.Select(g => g.sucu_Id).Distinct().Count())
        //            return "No puede ingresar dos veces la misma sucursal";

        //        _db.Colaboradores.Add(colaboradores);

        //        _db.SucursalesXColaboradores.AddRange(colaboradores.sucursalesXColaboradores);

        //        _db.SaveChanges();

        //        return _db.SucursalesXColaboradores.ToList().ToString();
        //    }
        //    catch
        //    {
        //        return "Intente más tarde";
        //    }
        //}
    }
}
 