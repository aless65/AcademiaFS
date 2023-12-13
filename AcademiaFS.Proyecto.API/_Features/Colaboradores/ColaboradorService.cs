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
            return Colaboradores;
        }

        public Respuesta InsertarColaboradores(tbColaboradores colaboradores)
        {
            try
            {
                _db.Colaboradores.Add(colaboradores);
                _db.SaveChanges();

                return Respuesta.Success(null, "Operación exitosa", "200"); 
            }
            catch
            {
                return Respuesta.Fault((string)"Intente más tarde", (string)"500", null);
            }
        }
    }
}
 