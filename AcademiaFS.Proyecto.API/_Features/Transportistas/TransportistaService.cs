using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly SistemaViajesDBContext _db;
        private readonly IMapper _mapper;

        public TransportistaService(SistemaViajesDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<Transportista> ListarTransportistas()
        {
            return _db.Transportistas.Where(x => x.Estado == true).ToList();
        }

        public Respuesta<object> InsertarTransportistas(TransportistaDto transportistaDto)
        {
            try
            {
                var transportista = _mapper.Map<Transportista>(transportistaDto);

                transportista.UsuaModificacion = null;
                transportista.FechaModificacion = null;

                _db.Transportistas.Add(transportista);

                _db.SaveChanges();

                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }

        public Respuesta<object> EditarTransportistas(Transportista transportista)
        {
            try
            {
                var transportistaAEDitar = _db.Transportistas.Where(x => x.IdTransportista == transportista.IdTransportista).FirstOrDefault();

                if (transportista != null)
                {
                    transportistaAEDitar.Nombres = transportista.Nombres;
                    transportistaAEDitar.Apellidos = transportista.Apellidos;
                    transportistaAEDitar.Identidad = transportista.Identidad;
                    transportistaAEDitar.TarifaKm = transportista.TarifaKm;
                    transportistaAEDitar.UsuaModificacion = transportista.UsuaModificacion;
                    transportistaAEDitar.FechaModificacion = DateTime.Now;

                    _db.SaveChanges();
                }


                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }

        public Respuesta<object> EliminarTransportistas(int Id)
        {
            try
            {
                var transportistaAEDitar = _db.Transportistas.Where(x => x.IdTransportista == Id).FirstOrDefault();

                transportistaAEDitar.Estado = false;

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
