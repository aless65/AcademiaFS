using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Viajes
{
    public class ViajeService
    {
        private readonly SistemaViajesDBContext _db;

        public ViajeService(SistemaViajesDBContext db)
        {
            _db = db;
        }   

        public List<Viaje> ListarViajes()
        {
            return _db.Viajes.ToList();
        }

        public Respuesta<object> InsertarViaje(Viaje viaje)
        {
            try
            {
                _db.Viajes.Add(viaje);

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
