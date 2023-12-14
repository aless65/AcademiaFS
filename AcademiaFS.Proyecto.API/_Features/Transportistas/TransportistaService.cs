using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly SistemaViajesDBContext _db;

        public TransportistaService(SistemaViajesDBContext db)
        {
            _db = db;
        }

        public List<Transportista> ListarTransportistas()
        {
            return _db.Transportistas.ToList();
        }

        public Respuesta<object> InsertarTransportistas(Transportista transportista)
        {
            try
            {
                _db.Transportistas.Add(transportista);

                _db.SaveChanges();

                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            } catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }
    }
}
