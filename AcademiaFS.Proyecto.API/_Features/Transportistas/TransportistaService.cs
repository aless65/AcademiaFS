using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API.Infrastructure.Repositories;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly SistemaViajesDBContext _db;
        private readonly IMapper _mapper;
        private readonly IRepository<Transportista> _repository;

        public TransportistaService(SistemaViajesDBContext db, IMapper mapper, IRepository<Transportista> repository)
        {
            _db = db;
            _mapper = mapper;
            _repository = repository;
        }

        public List<TransportistaDto> ListarTransportistas()
        {
            var transportistas = _repository.AsQueryable().Select(x => new TransportistaDto
            {
                Nombres = x.Nombres,
                Apellidos = x.Apellidos
            }).ToList();

            return transportistas;
        }

        public Respuesta<object> InsertarTransportistas(TransportistaDto transportistaDto)
        {
            try
            {
                //var transportista = _mapper.Map<Transportista>(transportistaDto);

                //transportista.UsuaModificacion = null;
                //transportista.FechaModificacion = null;

                //_db.Transportistas.Add(transportista);

                //_db.SaveChanges();
                var transportista = _mapper.Map<Transportista>(transportistaDto);
                _repository.Add(transportista);

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
