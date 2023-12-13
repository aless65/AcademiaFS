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
                item.tbSucursalesXColaboradores = _db.SucursalesXColaboradores.Where(x => x.cola_Id.Equals(item.cola_Id)).ToList();
            }
            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(tbColaboradores colaboradores)
        {
            try
            {
                _db.Colaboradores.Add(colaboradores);

                foreach (var item in colaboradores.tbSucursalesXColaboradores)
                {
                    _db.SucursalesXColaboradores.Add(item);
                }
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
 