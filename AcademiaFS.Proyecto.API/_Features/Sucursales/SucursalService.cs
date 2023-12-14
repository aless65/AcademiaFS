using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API.Infraestructure.SistemaViajes.Maps;

namespace AcademiaFS.Proyecto.API._Features.Sucursales
{
    public class SucursalService
    {
        private readonly SistemaViajesDBContext _db;

        public SucursalService(SistemaViajesDBContext db)
        {
            _db = db;
        }

        public List<Sucursal> ListarSucursales()
        {
            return _db.Sucursales.ToList(); 
        }
    }
}
