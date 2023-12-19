using AcademiaFS.Proyecto.API._Features.Transportistas.Dtos;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.Repositories;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API._Features.Transportistas
{
    public class TransportistaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportistaService(IMapper mapper, UnitOfWorkBuilder unitOfWorkBuilder)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorkBuilder.BuilderSistemaViajes();
        }

        public List<TransportistaDto> ListarTransportistas()
        {
            var transportistas = _unitOfWork.Repository<Transportista>().AsQueryable().Select(x => new TransportistaDto
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
                var transportista = _mapper.Map<Transportista>(transportistaDto);
                _unitOfWork.Repository<Transportista>().Add(transportista);

                _unitOfWork.SaveChanges();

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
                var transportistaAEDitar = _unitOfWork.Repository<Transportista>().Where(x => x.IdTransportista == transportista.IdTransportista).FirstOrDefault();

                if (transportista != null)
                {
                    transportistaAEDitar.Nombres = transportista.Nombres;
                    transportistaAEDitar.Apellidos = transportista.Apellidos;
                    transportistaAEDitar.Identidad = transportista.Identidad;
                    transportistaAEDitar.TarifaKm = transportista.TarifaKm;
                    transportistaAEDitar.UsuaModificacion = transportista.UsuaModificacion;
                    transportistaAEDitar.FechaModificacion = DateTime.Now;

                    _unitOfWork.SaveChanges();
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
                var transportistaAEDitar = _unitOfWork.Repository<Transportista>().Where(x => x.IdTransportista == Id).FirstOrDefault();

                transportistaAEDitar.Estado = false;

                _unitOfWork.SaveChanges();


                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500");
            }
        }
    }
}
